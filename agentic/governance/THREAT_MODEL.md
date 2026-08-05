# Threat model sintetico

## Asset

- codice sorgente;
- segreti;
- credenziali provider;
- repository Git;
- budget;
- log e artefatti;
- host di esecuzione.

## Minacce principali

- prompt injection da file/web;
- command injection;
- path traversal/symlink escape;
- esfiltrazione a provider esterni;
- uso fraudolento delle API key;
- escalation di costo;
- modifica non autorizzata del repository;
- replay o resume di checkpoint manomessi;
- SSRF tramite strumenti web/HTTP.

## Controlli

- policy deterministiche esterne all'LLM;
- worktree e path confinement;
- allow-list comandi e host;
- secrets redaction;
- approval human-in-the-loop;
- firma/hash artefatti e checkpoint;
- least privilege;
- audit immutabile o append-only.
