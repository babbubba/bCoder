# Sicurezza del runner unattended

Autopilot rimuove le conferme manuali. Usarlo esclusivamente in una worktree dedicata e senza credenziali di produzione.

## Consentito

- lettura e modifica nella worktree;
- `dotnet restore`, build, test e format;
- package restore dei progetti;
- comandi Git read-only;
- commit locali dopo review approvata;
- Docker Compose locale solo quando previsto dal task.

## Vietato

- push, merge, rebase, reset hard e force operation;
- modifica di repository o directory esterne alla worktree;
- sudo e comandi amministrativi;
- cancellazioni massive e prune;
- accesso a produzione, Kubernetes o database non locali;
- invio di codice a provider esterni;
- modelli paid o frontier;
- lettura di `.env`, secret store o token non necessari;
- disabilitazione di test o controlli per ottenere un falso successo.

## Preparazione raccomandata

- branch dedicata;
- backup o commit iniziale pulito;
- account senza privilegi amministrativi;
- servizi locali separati dai dati reali;
- nessuna credenziale reale nel workspace;
- monitoraggio spazio disco e memoria.
