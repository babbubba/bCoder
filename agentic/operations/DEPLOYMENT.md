# Deployment target MVP

## Componenti

- API/worker orchestratore;
- PostgreSQL;
- DS4 esterno sulla LAN;
- accesso OpenRouter opzionale;
- reverse proxy/TLS in ambiente condiviso.

## Ambienti

- Development: Docker Compose e DS4 LAN.
- Test: provider fake e PostgreSQL isolato.
- Production pilot: servizio systemd o container non privilegiato, PostgreSQL gestito, secrets store.

## Requisiti operativi

- health check provider;
- backup database;
- retention audit;
- timeout e circuit breaker;
- graceful shutdown;
- resume dei workflow in corso.
