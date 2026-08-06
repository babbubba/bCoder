# Regole operative estese

Questo file non deve essere letto automaticamente per ogni task. Viene consultato solo se incluso nel relativo context package o per configurare il runner.

## Gerarchia delle fonti

1. `AGENTS.md` nella root, incluso automaticamente da VS Code.
2. Il task assegnato.
3. `agentic/runner/context/TASK-XXX.md`.
4. Solo i documenti e le sezioni elencati in quel context package.
5. Il codice e i test strettamente necessari all’implementazione.

Il context package prevale sulle istruzioni legacy presenti nei task che chiedono di leggere genericamente progetto, architettura, sicurezza, quality gate o “documenti citati”.

## Gestione del contesto

- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md` durante implementazione o review.
- Non leggere l’intero backlog: usa solo la riga del task corrente e delle sue dipendenze.
- Non aprire intere directory ADR.
- Non rileggere documenti già sintetizzati nel report del tentativo corrente.
- Salva output lunghi di build/test in file di run e restituisci al coordinatore solo un riepilogo.
- Dopo massimo quattro letture iniziali, l’implementer deve iniziare l’implementazione oppure dichiarare `BLOCKED`.

## Metodo di implementazione

1. Verifica branch, baseline commit, dipendenze e diff esistente.
2. Leggi il task e il suo context package.
3. Formula un piano di massimo cinque punti.
4. Modifica in incrementi piccoli e coerenti.
5. Esegui formatter, build e test pertinenti.
6. Correggi al massimo tre tentativi complessivi coordinati dal runner.
7. Non effettuare commit: il commit è responsabilità del Project Runner dopo l’approvazione.
8. Restituisci un esito strutturato e sintetico.

## Review indipendente

Il reviewer:

- usa un subagent separato;
- non riceve il ragionamento dell’implementer;
- legge task, context package, diff e file modificati;
- può rieseguire build e test;
- non modifica il codice;
- restituisce `APPROVED`, `CHANGES_REQUESTED` o `BLOCKED`.

## Divieti

Senza intervento umano sono vietati:

- `git push`, merge, rebase, reset hard e force operation;
- eliminazioni massive;
- `docker system prune` e operazioni equivalenti;
- comandi privilegiati o su ambienti non locali;
- accesso a segreti non necessari;
- invio di codice o dati a provider esterni;
- uso di modelli a pagamento;
- modifica delle policy di sicurezza per aggirare un blocco;
- disabilitazione di test o analyzer per far passare il gate.

## Stop sicuro

Registra `Blocked` e interrompi il runner quando:

- serve una decisione funzionale o architetturale non documentata;
- mancano credenziali o servizi indispensabili;
- il repository contiene modifiche estranee non riconciliabili;
- build o test non sono eseguibili;
- tre cicli implementazione/review non risolvono i finding;
- il task richiede operazioni vietate.
