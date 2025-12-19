# AP.BTP – Deployment & Configuration Guide

Deze handleiding beschrijft stap voor stap hoe het AP.BTP project correct wordt opgezet en uitgerold met Docker & Traefik.

Na het volgen van deze gids draait de applicatie volledig:

- lokaal
- of in een gesloten netwerk
- met HTTPS (self-signed certificaten)
- met Auth0 authenticatie
- zonder manuele database setup (volledig automatisch)

---

## Overzicht architectuur
- Traefik
  - Reverse proxy + TLS termination + routing
- Web API
  - ASP.NET backend
- Web Apps
  - Operator (app.{DOMAIN})
  - Admin / Manager (admin.{DOMAIN})
- Database
  - Microsoft SQL Server (Docker)
- Authenticatie
  - Auth0 (RBAC + user management)

## Project structuur
De repository bestaat uit **twee hoofdcomponenten:**
```
Applied Software Project/
├── traefik/                # Niet in repo (zelf aanmaken)
│   ├── certs/              # SSL certificaten (self-signed)
│   ├── dynamic/
│   │   └── tls.yaml        # Traefik TLS configuratie
│   └── docker-compose.yaml
│
└── asp-btp/
    ├── docker-compose.yaml
    ├── .env                # Niet in repo (zelf aanmaken)
    └── ...
```
**Let op:** Traefik en de applicatie draaien in aparte Docker Compose projecten, maar delen hetzelfde Docker netwerk (proxy).

---

## Vereisten

Zorg ervoor dat de volgende software geïnstalleerd is of er een account voor is:

- Docker (v20.10+)
- Docker Compose (v2+)
- Auth0 account
- Pl@ntNet account

## Environment configuratie

De applicatie gebruikt environment variables die **niet** in de repository worden opgeslagen.

In de map `asp-btp/` moet een .env bestand aangemaakt worden:

```
# Database
SA_PASSWORD=

# General
DOMAIN=
WEB=
TLS=
ENVIRONMENT=

# API
BASE_URL=
PLANT_API=

# Traefik
TRAEFIK_CERT_PATH=

# Auth0
AUTH0_DOMAIN=
AUTH0_AUDIENCE=
AUTH0_CLIENT_ID=
AUTH0_CLIENT_SECRET=
AUTH0_MANAGEMENT_CLIENT_ID=
AUTH0_MANAGEMENT_CLIENT_SECRET=
```

Vul het `.env` bestand aan met de correcte waarden voor jouw omgeving zoals omschreven in onderstaande hoofdstukken.

---

## Database configuratie

De applicatie maakt gebruik van `Microsoft SQL Server` die in een Docker container draait.

Kies een sterk wachtwoord voor de SQL Server SA (System Administrator) account:

```env
SA_PASSWORD=JouwSterkWachtwoord123!
```

Vereisten voor het wachtwoord:
- Minimaal 8 karakters
- Hoofdletters, kleine letters, cijfers en speciale tekens

**Let op:** Dit wachtwoord wordt gebruikt voor de interne database connectie. Bewaar dit veilig.

---

## General

Deze variabelen bepalen de algemene configuratie van de applicatie.

### DOMAIN
Het domein waarop de applicatie draait.

```env
DOMAIN=jouwdomein.be
```

De applicatie zal beschikbaar zijn op:
- Operator app: `app.{DOMAIN}`
- Admin/Manager app: `admin.{DOMAIN}`

**Voorbeelden:**
- Productie: `DOMAIN=treesitter.be` → `app.treesitter.be` en `admin.treesitter.be`
- Development: `DOMAIN=localhost` → `app.localhost` en `admin.localhost`

### ENVIRONMENT

De omgeving waarin de applicatie draait.

```env
ENVIRONMENT=Production
```

Mogelijke waarden:
- `Development`: Lokale ontwikkelomgeving met uitgebreide logging
- `Production`: Productieomgeving met geoptimaliseerde performance

---

## API
Configuratie voor de backend API en externe services.

### BASE_URL

De interne Docker URL naar de Web API.

```env
BASE_URL=http://webapi/api/v1/
```

**Let op:** Dit is de interne Docker service naam. Verander deze waarde niet tenzij je de service naam in `docker-compose.yml` aanpast.

### PLANT_API

De API key voor [Pl@ntNet](https://my.plantnet.org/), gebruikt voor plantenherkenning via foto's.

**API Key verkrijgen:**

1. Ga naar https://my.plantnet.org/
2. Maak een account aan of log in
3. Ga naar **Settings/API key**
4. Klik op **Generate new API key**
5. Kopieer de gegenereerde key

```env
PLANT_API=jouw_plantnet_api_key_hier
```
**Let op:** Laat onder `Configure key settings (Cors)` de optie `expose my API key` uit staan.

**Rate limits:** Gratis accounts hebben een limiet van 500 requests per dag. Voor productie is een betaald account aangeraden.


---

## Traefik
Traefik fungeert als reverse proxy en handelt HTTPS/SSL certificaten af voor de applicatie.

### Environment variabelen
#### TRAEFIK_CERT_PATH

Het pad waar SSL/TLS certificaten worden opgeslagen.

```env
TRAEFIK_CERT_PATH=../traefik/certs
```

#### WEB

De Traefik entrypoint die gebruikt wordt voor HTTPS verkeer.

```env
WEB=websecure
```

Laat deze waarde op `websecure` staan.

#### TLS

Bepaalt of TLS/SSL certificaten worden gebruikt.

```env
TLS=true
```

- `true`: HTTPS wordt afgedwongen (aanbevolen voor productie)
- `false`: Alleen HTTP (enkel voor lokale development zonder certificaten)

### Traefik configuratie
#### Docker netwerk

Traefik en alle applicaties communiceren via dit netwerk:

``` yaml
networks:
  proxy:
    name: proxy
```
Alle services die via Traefik bereikbaar moeten zijn, moeten op dit netwerk zitten.

#### Traefik docker-compose.yaml
Traefik draait in de map `traefik/`.

```yaml
services:
  traefik:
    image: traefik:v2.11
    container_name: traefik
    restart: unless-stopped
    security_opt:
      - no-new-privileges:true

    networks:
     # Connect to the 'traefik_proxy' overlay network for inter-container communication across nodes
      - proxy

    ports:
      - "80:80"
      - "443:443"
      - "8080:8080"

    volumes:
      - /var/run/docker.sock:/var/run/docker.sock
      - ./certs:/certs:ro
      - ./dynamic:/dynamic:ro
      - /usr/bin/docker:/usr/bin/docker:ro

    command:
      # EntryPoints
      - "--entrypoints.web.address=:80"
      - "--entrypoints.web.http.redirections.entrypoint.to=websecure"
      - "--entrypoints.web.http.redirections.entrypoint.scheme=https"
      - "--entrypoints.web.http.redirections.entrypoint.permanent=true"
      - "--entrypoints.websecure.address=:443"
      - "--entrypoints.websecure.http.tls=true"

      # Attach the static configuration tls.yaml file that contains the tls configuration settings
      - "--providers.file.filename=/dynamic/tls.yaml"

      # Providers
      - "--providers.docker=true"
      - "--providers.docker.exposedbydefault=false"
      - "--providers.docker.network=proxy"

      # API & Dashboard
      - "--api.dashboard=true"
      - "--api.insecure=false"

      # Observability
      - "--log.level=INFO"
      - "--accesslog=true"
      - "--metrics.prometheus=true"

  # Traefik Dynamic configuration via Docker labels
    labels:
      # Enable self‑routing
      - "traefik.enable=true"

      # Dashboard router
      - "traefik.http.routers.dashboard.rule=Host(`traefik.localhost`)"
      - "traefik.http.routers.dashboard.entrypoints=websecure"
      - "traefik.http.routers.dashboard.service=api@internal"
      - "traefik.http.routers.dashboard.tls=true"

      # Basic‑auth middleware
      - "traefik.http.middlewares.dashboard-auth.basicauth.users=admin:$$apr1$$XcKloz0K$$CqsVP/5P6adqAGHKni2Xw/"
      - "traefik.http.routers.dashboard.middlewares=dashboard-auth@docker"
    environment:
      - DOCKER_API_VERSION=1.52

networks:
  proxy:
    name: proxy
```

Belangrijkste functies:
- HTTP → HTTPS redirect
- TLS via self-signed certificaat
- Dashboard beveiligd met Basic Auth
- Docker provider met labels

Traefik exposeert:
- 80 → HTTP (redirect)
- 443 → HTTPS

#### TLS configuratie (self-signed)
Maak in `traefik/dynamic` de volgende `tls.yaml` aan:

``` yaml
tls:
  certificates:
    - certFile: /certs/local.crt
      keyFile:  /certs/local.key
```

#### Certificaten genereren
``` bash
cd traefik
mkdir -p certs

openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
  -keyout certs/local.key \
  -out certs/local.crt \
  -subj "/CN=localhost"
```
**Let op:** Browser waarschuwing is normaal doordat het een self-signed certificaat is.

### Traefik dashboard
- URL: https://traefik.localhost
- Beveiligd met Basic Auth

De credentials worden ingesteld via deze label:
```yaml
traefik.http.middlewares.dashboard-auth.basicauth.users=
```

De hash wordt aangemaakt met:
```bash
htpasswd -nb admin jouw_wachtwoord
```

Vervang de gegenereerde hash in `docker-compose.yaml`.

---

## Auth0

De applicatie gebruikt Auth0 voor:
- Authenticatie via e-mail & wachtwoord (Password Grant)
- User management (users aanmaken)
- Role-based access control (RBAC)

De onderstaande configuratie is nodig voor een juist werkende applicatie.

---

### 1. Auth0 Tenant

Maak een Auth0 account aan via:

https://auth0.com

Gebruik een bestaande tenant of maak een nieuwe aan.

Noteer het **Auth0 Domain**, bijvoorbeeld:

```
dev-xxxxxx.eu.auth0.com
```

Gebruik dit in `.env`:

```env
AUTH0_DOMAIN=dev-xxxxxx.eu.auth0.com
```

---

### 2. Database Connection (Username / Password)

De applicatie gebruikt een **database connection** voor username/password authenticatie.

Controleer het volgende:

1. Ga naar **Authentication → Database**
2. Zorg dat de connection **"Username-Password-Authentication"** bestaat
3. Zorg dat deze **enabled** is

---

### 3. Auth0 API (Audience)

De applicatie vereist een custom API voor access tokens.

#### Stappen:

1. Ga naar **Applications → APIs**
2. Klik **Create API**
3. Vul in:
   - **Name**: `AP.BTP API`
   - **Identifier**: bijvoorbeeld:
     ```
     https://api.apbtp.local
     ```
   - **Signing Algorithm**: RS256

Gebruik de identifier als audience:

```env
AUTH0_AUDIENCE=https://api.apbtp.local
```

---

### 4. Regular Web Application (Login / Password Grant)

Voor login via e-mail en wachtwoord wordt de **Password Grant (ROPG)** gebruikt.

#### Stappen:

1. Ga naar **Applications → Applications**
2. Klik **Create Application**
3. Kies type **Regular Web Application**

#### Settings:

- **Grant Types**:
  - ✅ Password
- **Token Endpoint Authentication Method**:
  - `Post`

Noteer de credentials:

```env
AUTH0_CLIENT_ID=...
AUTH0_CLIENT_SECRET=...
```

---

### 5. Machine-to-Machine Application (Management API)

De applicatie gebruikt de Auth0 Management API om:
- Users aan te maken
- Rollen toe te wijzen

#### Stappen:

1. Ga naar **Applications → Applications**
2. Klik **Create Application**
3. Kies **Machine to Machine Application**
4. Selecteer de **Auth0 Management API**

#### Vereiste permissions:

- `read:roles`
- `create:users`
- `read:users`
- `update:users`
- `read:role_members`
- `create:role_members`

Noteer:

```env
AUTH0_MANAGEMENT_CLIENT_ID=...
AUTH0_MANAGEMENT_CLIENT_SECRET=...
```

---

### 6. Rollen configureren

De applicatie verwacht dat rollen **vooraf bestaan** in Auth0.

#### Stappen:

1. Ga naar **User Management → Roles**
2. Maak de benodigde rollen aan: `Admin`, `Manager` en `Operator`

---

## Applicatie starten

Zodra het `.env` bestand correct is ingevuld kan de applicatie worden gestart.

### Stap 1: Traefik opstarten

Navigeer naar de traefik folder en start Traefik:

```bash
cd traefik
docker compose up -d
```

### Stap 2: Applicatie opstarten

Ga terug naar de applicatie folder en start de volledige applicatie:

```bash
cd asp-btp
docker compose up -d
```

### Eerste keer opstarten

Bij de eerste keer opstarten worden automatisch database migraties uitgevoerd en het schema aangemaakt. Dit kan enkele minuten duren.

**Status controleren:**

```bash
docker compose ps
```

Je zou de volgende services moeten zien met status `running`:
- `traefik`
- `webapi`
- `webapp-operator`
- `webapp-admin`
- `sqlserver`

---

## Toegang tot de applicatie

Afhankelijk van de configuratie is de website beschikbaar op:

- operator app: `app.{DOMAIN}`
- admin en manager app: `admin.{DOMAIN}`

---

## Applicatie stoppen

### Alles stoppen maar data behouden

```bash
docker compose down
```

### Alles stoppen én data verwijderen

**Let op:** Dit verwijdert alle data in de database!

```bash
docker compose down -v
```