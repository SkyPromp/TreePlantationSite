# AP.BTP – Deployment & Configuration Guide

Deze README beschrijft stap voor stap hoe je het volledige project correct kunt opzetten en starten.

Na het volgen van deze handleiding kan de applicatie lokaal of in productie worden uitgerold.

---

## Vereisten

Zorg ervoor dat de volgende software geïnstalleerd is of er een account voor is:

- Docker
- Docker Compose (v2+)
- Auth0 account
- Pl@ntNet account

---


## Environment configuratie

De applicatie gebruikt environment variables die **niet** in de repository worden opgeslagen.

### 1. .env bestand aanmaken

Maak een `.env` bestand aan op basis van dit voorbeeld:

```
# Database
SA_PASSWORD=

# General
DOMAIN=
WEB=websecure
TLS=true
ENVIRONMENT=Production

# API
BASE_URL=
Api_BaseUrl=
PLANT_API=

# Traefik
TRAEFIK_CERT_PATH=../traefik/certs

# Auth0
AUTH0_DOMAIN=
AUTH0_AUDIENCE=
AUTH0_CLIENT_ID=
AUTH0_CLIENT_SECRET=
AUTH0_MANAGEMENT_CLIENT_ID=
AUTH0_MANAGEMENT_CLIENT_SECRET=
```

Vul het `.env` bestand aan met de correcte waarden voor jouw omgeving zoals omschreven in onderstaande hoofdstukken

---

## Database

De applicatie maakt gebruik van `Microsoft SQL Server`.

hiervoor dient enkel nog een wachtwoord voor gekozen te worden.

Vul bij deze environment variabele een zelfgekozen wachtwoord in

```env
SA_PASSWORD=
```

---

## General

---

## API

---

## Traefik

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

Gebruik de identifier als audience: bijvoorbeeld:

```env
AUTH0_AUDIENCE=https://api.apbtp.local
```

---

### 4. Regular Web Application (Login / Password Grant)

Voor login via e-mail en wachtwoord wordt de **Resource Owner Password Grant** gebruikt.

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
2. Maak de benodigde rollen aan:`Admin`, `Manager` en `Operator`

---

## Applicatie starten

Zodra het `.env` bestand correct is ingevuld kan de applicatie worden gestart.

1. voer volgend commando uit in de traefik folder
2. voer daarna hetzelfde commando uit in de root folder

```bash
docker compose up -d
```

---

## Toegang tot de applicatie

Afhankelijk van de configuratie is de website beschikbaar op:

- operator app: `app.{DOMAIN}`
- admin en manager app: `admin.{DOMAIN}`

---