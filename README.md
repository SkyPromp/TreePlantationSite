# AP.BTP – Deployment & Configuration Guide

Deze handleiding beschrijft stap voor stap hoe het AP.BTP project correct wordt opgezet en uitgerold met Docker & Traefik.

Na het volgen van deze gids draait de applicatie volledig:

- lokaal of in een gesloten netwerk
- met HTTPS (self-signed certificaten)
- met Auth0 authenticatie
- zonder manuele database setup (volledig automatisch)

---

## Overzicht architectuur

- **Traefik**: Reverse proxy + TLS termination + routing
- **Web API**: ASP.NET backend
- **Web Apps**: 
  - Operator (`app.{DOMAIN}`)
  - Admin / Manager (`admin.{DOMAIN}`)
- **Database**: Microsoft SQL Server (Docker)
- **Authenticatie**: Auth0 (RBAC + user management)

## Project structuur
De repository bestaat uit **twee hoofdcomponenten:**
```
BTP/
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

**Let op:** Traefik en de applicatie draaien in aparte Docker Compose projecten, maar delen hetzelfde Docker netwerk (`proxy`).

---

## Vereisten

Zorg ervoor dat de volgende software geïnstalleerd is:

- Docker (v20.10+)
- Docker Compose (v2+)
- OpenSSL (voor certificaten)
- Git

**Optioneel** (voor Traefik dashboard wachtwoord):
- Apache2-utils (Ubuntu/Debian: `sudo apt-get install apache2-utils`)

Daarnaast heb je accounts nodig voor:
- [Auth0](https://auth0.com)
- [Pl@ntNet](https://my.plantnet.org/)

---

## Quick start - Vanaf nul opzetten

### Stap 1: Repository opzetten

```bash
mkdir -p BTP
cd BTP
git clone https://gitlab.apstudent.be/bachelor-it/applied-software-project/25-26/team-15/asp-btp.git
```

---

### Stap 2: Docker network aanmaken

```bash
docker network create proxy
```

Dit netwerk zorgt voor communicatie tussen Traefik en de applicatie services.

---

### Stap 3: Traefik folder structuur aanmaken

```bash
mkdir -p traefik/certs
mkdir -p traefik/dynamic
cd traefik
```

---

### Stap 4: Traefik docker-compose.yaml aanmaken

Maak het bestand `traefik/docker-compose.yaml` aan met de volgende inhoud:

```yaml
services:
  traefik:
    image: traefik:v2.11
    container_name: traefik
    restart: unless-stopped
    security_opt:
      - no-new-privileges:true

    networks:
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

      # TLS configuratie
      - "--providers.file.filename=/dynamic/tls.yaml"

      # Docker provider
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

    labels:
      # Enable self-routing
      - "traefik.enable=true"

      # Dashboard router
      - "traefik.http.routers.dashboard.rule=Host(`traefik.localhost`)"
      - "traefik.http.routers.dashboard.entrypoints=websecure"
      - "traefik.http.routers.dashboard.service=api@internal"
      - "traefik.http.routers.dashboard.tls=true"

      # Basic auth middleware (optional)
      #- "traefik.http.middlewares.dashboard-auth.basicauth.users=user:hashedpassword"
      #- "traefik.http.routers.dashboard.middlewares=dashboard-auth@docker"

    environment:
      - DOCKER_API_VERSION=1.52

networks:
  proxy:
    external: true
```

**Belangrijke functies:**
- HTTP → HTTPS redirect (alle verkeer wordt automatisch naar HTTPS gestuurd)
- TLS via self-signed certificaat
- Docker provider met labels (automatische service discovery)
- Optioneel: Dashboard beveiligd met Basic Auth

**Exposed poorten:**
- `80`: HTTP (redirect naar HTTPS)
- `443`: HTTPS
- `8080`: Prometheus metrics

---

### Stap 5: TLS configuratie aanmaken

Maak het bestand `traefik/dynamic/tls.yaml` aan:

```yaml
tls:
  certificates:
    - certFile: /certs/local.crt
      keyFile: /certs/local.key
```

Dit bestand vertelt Traefik waar de SSL certificaten te vinden zijn.

---

### Stap 6: Self-signed certificaten genereren

```bash
cd traefik
openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
  -keyout certs/local.key \
  -out certs/local.crt \
  -subj "/CN=localhost"
```

**Let op:** Je browser zal een security warning geven. Dit is normaal voor self-signed certificaten. Klik op "Advanced" -> "Confirm".

---

### Stap 7: Dashboard wachtwoord instellen (optioneel)

Standaard is er geen wachtwoord voor `https://traefik.localhost`.

#### Om wachtwoord authenticatie aan te zetten:

Uncomment de volgende lijnen in `traefik/docker-compose.yaml`:

```yaml
#- "traefik.http.middlewares.dashboard-auth.basicauth.users=user:hashedpassword"
#- "traefik.http.routers.dashboard.middlewares=dashboard-auth@docker"
```

#### Een gebruikersnaam/wachtwoord combinatie genereren:

```bash
sudo apt-get install apache2-utils
htpasswd -nb jouw_gebruiker jouw_wachtwoord
```

**Output voorbeeld:**
```
gebruiker:$apr1$xyz123$abc...
```

Vervang de volledige waarde (inclusief `user:`) in `docker-compose.yaml` bij:
```yaml
- "traefik.http.middlewares.dashboard-auth.basicauth.users=gebruiker:$$apr1$$..."
```

**Let op:** Verdubbel de `$` tekens: `$` wordt `$$` in docker-compose!

---

### Stap 8: Traefik starten

```bash
docker compose up -d
```

**Controleer of het werkt:**

```bash
docker compose ps
```

Je zou `traefik` met status `UP` moeten zien.

**Test het dashboard:**

Open `https://traefik.localhost` in je browser:
- Accept de security warning (self-signed certificaat)
- Indien authenticatie aan staat: log in met jouw gegevens

Als dit werkt, is Traefik correct geconfigureerd!

---

### Stap 9: .env bestand aanmaken voor applicatie

De applicatie gebruikt environment variables die **niet** in de repository worden opgeslagen.

```bash
cd ../asp-btp
```

Maak een `.env` bestand aan met de volgende template:

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

## Environment configuratie

### Database configuratie

De applicatie maakt gebruik van `Microsoft SQL Server` die in een Docker container draait.

Kies een sterk wachtwoord voor de SQL Server SA (System Administrator) account:

```env
SA_PASSWORD=JouwSterkWachtwoord123!
```

**Vereisten:**
- Minimaal 8 karakters
- Hoofdletters, kleine letters, cijfers en speciale tekens

**Let op:** Dit wachtwoord wordt gebruikt voor de interne database connectie. Bewaar dit veilig.

---

### General

Deze variabelen bepalen de algemene configuratie van de applicatie.

---

#### DOMAIN
Het domein waarop de applicatie draait.

```env
DOMAIN=jouwdomein.be
```

De applicatie zal beschikbaar zijn op:
- Operator app: `app.{DOMAIN}`
- Admin/Manager app: `admin.{DOMAIN}`

**Voorbeelden:**
- Development: `DOMAIN=localhost` -> `app.localhost` en `admin.localhost`
- Productie: `DOMAIN=treesitter.be` -> `app.treesitter.be` en `admin.treesitter.be`

---

#### WEB

De Traefik entrypoint die gebruikt wordt voor HTTPS verkeer.

```env
WEB=websecure
```

Laat deze waarde op `websecure` staan.

---

#### TLS

Bepaalt of TLS/SSL certificaten worden gebruikt.

```env
TLS=true
```

- `true`: HTTPS wordt afgedwongen (aanbevolen voor productie)
- `false`: Alleen HTTP (enkel voor lokale development zonder certificaten)

---

### ENVIRONMENT

De omgeving waarin de applicatie draait.

```env
ENVIRONMENT=Production
```

Mogelijke waarden:
- `Development`: Lokale ontwikkelomgeving met uitgebreide logging
- `Production`: Productieomgeving met geoptimaliseerde performance

---

### API
Configuratie voor de backend API en externe services.

#### BASE_URL

De interne Docker URL naar de Web API.

```env
BASE_URL=http://webapi/api/v1/
```

**Let op:** Dit is de interne Docker service naam. Verander deze waarde niet tenzij je de service naam in `docker-compose.yml` aanpast.

#### PLANT_API

De API key voor [Pl@ntNet](https://my.plantnet.org/), gebruikt voor plantenherkenning via foto's.

**API Key verkrijgen:**

1. Ga naar https://my.plantnet.org/
2. Maak een account aan of log in
3. Ga naar **Settings** -> **API key**
4. Klik op **Generate new API key**
5. Kopieer de gegenereerde key

```env
PLANT_API=jouw_plantnet_api_key
```

**Let op:** Laat onder "Configure key settings (CORS)" de optie "expose my API key" **uitgeschakeld**.

**Rate limits:** Gratis accounts hebben een limiet van 500 requests per dag. Voor productie is een betaald account aangeraden.

---

### Traefik

#### TRAEFIK_CERT_PATH

Het relatieve pad naar de Traefik certificaten folder.

```env
TRAEFIK_CERT_PATH=../traefik/certs
```

Dit pad is relatief ten opzichte van de `asp-btp/` folder en wijst naar de certificaten die we eerder hebben gegenereerd.

---

### Auth0

De applicatie gebruikt Auth0 voor:
- Authenticatie via e-mail & wachtwoord (Password Grant)
- User management (users aanmaken)
- Role-based access control (RBAC)

De onderstaande configuratie is nodig voor een juist werkende applicatie.


#### 1. Auth0 Tenant

1. Ga naar https://auth0.com
2. Maak een account aan of log in
3. Maak een nieuwe tenant aan (of gebruik een bestaande)

Noteer het **Auth0 Domain** in `.env`:

```env
AUTH0_DOMAIN=dev-xxxxxx.eu.auth0.com
```

---

#### 2. Database Connection (Username / Password)

Controleer het volgende:

1. Ga in je Auth0 Dashboard naar **Authentication -> Database**
2. Zorg dat de connection **"Username-Password-Authentication"** bestaat
3. Zorg dat deze **enabled** is

---

#### 3. Auth0 API (Audience)

1. Ga naar **Applications -> APIs**
2. Klik **Create API**
3. Vul in:
   - **Name**: `AP.BTP API`
   - **Identifier**: `https://api.apbtp.local` (dit mag een fictieve URL zijn)
   - **Signing Algorithm**: `RS256`
4. Klik **Create**

Gebruik de identifier in `.env`:

```env
AUTH0_AUDIENCE=https://api.apbtp.local
```

---

#### 4. Regular Web Application (Login / Password Grant)

1. Ga naar **Applications -> Applications**
2. Klik **Create Application**
3. Kies type **Regular Web Application**
4. Geef het een naam, bijv. "AP.BTP Web"

**Configuratie:**
1. Ga naar de **Settings** tab
2. Scroll naar **Advanced Settings** -> **Grant Types**
3. Vink **Password** aan
4. Zet **Token Endpoint Authentication Method** op `Post`
5. Klik **Save Changes**

Noteer de credentials:

```env
AUTH0_CLIENT_ID=...
AUTH0_CLIENT_SECRET=...
```

---

#### 5. Machine-to-Machine Application (Management API)

1. Ga naar **Applications** -> **Applications**
2. Klik **Create Application**
3. Kies **Machine to Machine Applications**
4. Geef het een naam, bijv. "AP.BTP Management"
5. Selecteer **Auth0 Management API**
6. Klik **Authorize**

**Permissions instellen:**
1. Selecteer de volgende permissions:
   - `read:roles`
   - `create:users`
   - `read:users`
   - `update:users`
   - `read:role_members`
   - `create:role_members`
2. Klik **Authorize**

Noteer de credentials:

```env
AUTH0_MANAGEMENT_CLIENT_ID=Hzqvi4pnJRyCOuzGp1lj7TfORPLeJm8N
AUTH0_MANAGEMENT_CLIENT_SECRET=9SG1Fzf8qVPoeAe-W0eUZYqkNRRZ...
```

---

#### 6. Rollen aanmaken

1. Ga naar **User Management** -> **Roles**
2. Klik **Create Role**
3. Maak de volgende rollen aan:
   - **Admin**: Beheer van volledige applicatie inhoud
   - **Manager**: Beheer van operators en taken
   - **Operator**: Uitvoeren van veldwerk

Voor elke rol:
1. Geef een **Name** en **Description**
2. Klik **Create**

---

#### 7. Eerste gebruiker aanmaken

Voor **demo en development doeleinden** zijn er standaard 3 gebruikers aanwezig:

| Rol | Email | Wachtwoord |
|-----|-------|------------|
| Admin | `Admin123@admin.admin` | `Admin123@admin.admin` |
| Manager | `Manager123@manager.manager` | `Manager123@manager.manager` |
| Operator | `Operator123@operator.operator` | `Operator123@operator.operator` |

Deze gebruikers worden:
- Manueel aangemaakt in Auth0
- Toegevoegd aan de database (via seed data)
- Gekoppeld aan de juiste rollen

**Let op:** Deze demo accounts zijn **niet geschikt voor productie**! Zie hieronder voor productie setup.

---

##### Productie setup (handmatig gebruiker aanmaken)

Voor **productie** moet je handmatig een admin gebruiker aanmaken:

**Stap 1: Gebruiker in Auth0 aanmaken**

1. Ga naar **User Management** → **Users**
2. Klik **Create User**
3. Vul in:
   - **Email**: `jouw.email@bedrijf.be`
   - **Password**: Kies een sterk wachtwoord
   - **Connection**: `Username-Password-Authentication`
4. Klik **Create**

**Stap 2: Admin rol toewijzen**

1. Klik op de zojuist aangemaakte gebruiker
2. Ga naar het tabblad **Roles**
3. Klik **Assign Roles**
4. Selecteer `Admin`
5. Klik **Assign**

**Stap 3: Gebruiker in database toevoegen**

De gebruiker moet ook in de applicatie database worden toegevoegd. Dit gebeurt automatisch bij de eerste login, of kan handmatig via SQL:

```sql
INSERT INTO [dbo].[User] (Auth0Id, FirstName, LastName, PhoneNumber, Email, IsApproved, Role, IsDeleted)
VALUES 
  ('auth0|xxxxx', 'Jouw', 'Naam', '+32123456789', 'jouw.email@bedrijf.be', 1, 'Admin', 0);
```

De `Auth0Id` kan je vinden in Auth0 → Users → (jouw gebruiker) → Details → "user_id".

**Voor productie deployment:**
1. Maak een eigen admin account aan volgens bovenstaande stappen
2. Update eventueel seeding code om demo accounts niet meer toe te voegen

---

## Applicatie starten

Zodra het `.env` bestand correct is ingevuld kan de applicatie worden gestart.

### Stap 1: Controleer of Traefik draait

```bash
cd ../traefik
docker compose ps
```

Als Traefik niet draait:

```bash
docker compose up -d
```

---

### Stap 2: Start de applicatie

```bash
cd ../asp-btp
docker compose up -d
```

---

### Stap 3: Wacht op database initialisatie

Bij de eerste keer opstarten worden automatisch:
- Database migraties uitgevoerd
- Database schema aangemaakt
- Seed data ingeladen (indien geconfigureerd)

**Dit kan 2-3 minuten duren.**

**Status controleren:**

```bash
docker compose ps
```

Je zou de volgende services moeten zien met status `UP`:
- `db`
- `webapi`
- `webapp`
- `webapp-maintenance`


**Als een service niet draait:**

```bash
docker compose logs <service-naam>
```

---

## Toegang tot de applicatie

Na succesvolle opstart is de applicatie beschikbaar op:

| Service | URL | Beschrijving |
|---------|-----|--------------|
| Operator app | `https://app.{DOMAIN}` | Voor veldwerkers |
| Admin app | `https://admin.{DOMAIN}` | Voor beheerders en managers |
| Traefik dashboard | `https://traefik.{DOMAIN}` | Monitoring en routing overzicht |

## Applicatie beheren

### Status controleren

```bash
cd asp-btp
docker compose ps
```

### Logs bekijken

**Alle services:**
```bash
docker compose logs -f
```

**Specifieke service:**
```bash
docker compose logs -f webapi
docker compose logs -f webappmaintenance
docker compose logs -f webapp
docker compose logs -f db
```

**Laatste 100 regels:**
```bash
docker compose logs --tail=100 webapi
```

### Applicatie herstarten

```bash
docker compose restart
```

**Specifieke service:**
```bash
docker compose restart webapi
```

### Applicatie stoppen

**Stoppen maar data behouden:**
```bash
docker compose down
```

**Stoppen én alle data verwijderen:**
```bash
docker compose down -v
```

**Let op:** Dit verwijdert de volledige database!

## Productie deployment

Voor productie zijn aanvullende stappen vereist.

### 1. Let's Encrypt certificaten

Voor echte SSL certificaten in productie gebruik je Let's Encrypt.

**Vereisten:**
- Een publiek domein (bijv. `treesitter.be`)
- DNS correct geconfigureerd (A-record wijst naar server IP)
- Poorten 80 en 443 publiek toegankelijk

**Traefik aanpassen voor Let's Encrypt:**

Voeg toe aan `traefik/docker-compose.yaml` command:
```yaml
# Let's Encrypt
- "--certificatesresolvers.letsencrypt.acme.email=jouw@email.com"
- "--certificatesresolvers.letsencrypt.acme.storage=/letsencrypt/acme.json"
- "--certificatesresolvers.letsencrypt.acme.httpchallenge=true"
- "--certificatesresolvers.letsencrypt.acme.httpchallenge.entrypoint=web"
```

Voeg volume toe:
```yaml
volumes:
  - ./letsencrypt:/letsencrypt
```

Update TLS in je applicatie labels:
```yaml
- "traefik.http.routers.app.tls.certresolver=letsencrypt"
```

### 2. Firewall configuratie

Open de benodigde poorten:

```bash
sudo ufw allow 80/tcp
sudo ufw allow 443/tcp
sudo ufw allow 22/tcp   # SSH
```

### 3. Environment aanpassen

Update `.env` voor productie:

```env
DOMAIN=treesitter.be
ENVIRONMENT=Production
TLS=true
```

Update Traefik labels in `docker-compose.yaml` van `localhost` naar je domein:
```yaml
- "traefik.http.routers.dashboard.rule=Host(`traefik.treesitter.be`)"
```

## Changelog

- **v1.0**: Initiele release
  - Docker Compose setup
  - Traefik reverse proxy
  - Auth0 integratie
  - Self-signed certificaten voor development
