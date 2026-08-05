# Progetto: Italcom Agent Orchestrator

## Problema

Serve un sistema interno capace di ricevere richieste di sviluppo software, pianificarle, scomporle e implementarle usando prioritariamente modelli locali o gratuiti. Il sistema deve poter delegare parti del lavoro a modelli esterni senza cedere il controllo su sicurezza, privacy, costo e qualità.

## Obiettivo MVP

Realizzare un orchestratore che:

1. usa DS4/DeepSeek locale come planner e manager;
2. crea task strutturati e dipendenze;
3. lavora su repository Git tramite worktree isolate;
4. delega implementazioni e revisioni ad agenti specializzati;
5. predilige locale e modelli gratuiti;
6. usa modelli a pagamento solo dopo quality gate falliti e approvazione;
7. esegue build, test e analisi statica;
8. mantiene stato, audit, checkpoint e costi;
9. espone API REST/SSE e una CLI;
10. non esegue merge o push senza approvazione esplicita.

## Stack iniziale

- C# e ASP.NET Core.
- Microsoft Agent Framework.
- Microsoft.Extensions.AI / client OpenAI-compatible.
- PostgreSQL.
- OpenTelemetry.
- Docker Compose per sviluppo.
- xUnit per test.
- CLI .NET come interfaccia iniziale.

Il target iniziale è `.NET 8`. Se la versione selezionata di Microsoft Agent Framework richiede un target successivo, il cambio deve essere registrato con ADR prima di modificare la solution.

## Fuori perimetro MVP

- UI Angular completa.
- esecuzione completamente autonoma senza approvazioni;
- merge automatico su branch protetti;
- gestione Kubernetes;
- supporto a qualunque linguaggio o build system;
- training o fine-tuning dei modelli;
- sostituzione di GitHub/GitLab come sistema di code review.

## Utenti

- sviluppatore che avvia un task da CLI/API;
- revisore che approva uso di provider esterni o modifiche ad alto rischio;
- amministratore che configura modelli, budget e policy;
- agente manager locale;
- agenti esecutori e revisori.

## Requisiti non funzionali

- nessuna chiave API in prompt, log o database in chiaro;
- idempotenza dei workflow;
- possibilità di riprendere dopo crash;
- audit di ogni delega e tool call rilevante;
- isolamento filesystem per task;
- timeout e cancellazione propagati;
- costi registrati per task, modello e tentativo;
- policy di privacy applicata prima dell'invio esterno;
- test riproducibili.
