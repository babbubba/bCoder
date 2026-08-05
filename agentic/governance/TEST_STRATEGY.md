# Strategia di test

## Unit test

Coprire:

- invarianti dominio;
- routing e ranking;
- privacy gate;
- budget e approval;
- retry/escalation;
- parsing e normalizzazione provider;
- path validation;
- command policy.

## Integration test

Usare test container o Docker Compose per:

- PostgreSQL;
- fake DS4/OpenRouter HTTP server;
- migrazioni;
- persistence e checkpoint;
- SSE/API.

## Contract test provider

- request Chat Completions;
- tool calls;
- reasoning separato;
- errori e rate limit;
- usage tokens/cost;
- timeout e cancellazione.

## End-to-end

Scenario A: task risolto localmente.

Scenario B: primo tentativo locale fallisce, secondo riesce.

Scenario C: locale fallisce, selezione free, quality gate riesce.

Scenario D: richiesta paid bloccata fino ad approvazione.

Scenario E: crash simulato e resume da checkpoint.
