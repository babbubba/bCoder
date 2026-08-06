# Guida al contesto

## Modalità manuale

- **32K**: fix circoscritti, singoli adapter, test, endpoint o modifiche entro pochi file.
- **64K**: bootstrap, dominio, routing, sicurezza, workflow e modifiche trasversali.

## Modalità autonoma

Il Project Runner viene avviato una sola volta con **Long 64K**. I subagent ereditano il modello.

Il budget indicato in `agentic/runner/context/TASK-XXX.md` controlla quanto contesto può essere caricato:

### Budget operativo 32K

- task e context package;
- massimo due documenti aggiuntivi;
- massimo dieci file applicativi prima della prima modifica;
- niente esplorazione architetturale;
- output di terminale sintetizzato.

### Budget operativo 64K

- task e context package;
- massimo tre documenti elencati;
- file applicativi direttamente coinvolti;
- nessuna lettura ricorsiva o dell’intero piano.

## Regole anti-compattazione

- non leggere `ALL-IN-ONE-PLAN.md` durante esecuzione;
- non leggere tutti gli ADR;
- non caricare task precedenti per ricostruire lo stato: usare Git e i report;
- salvare log lunghi sotto `agentic/runner/runs/`;
- il parent riceve solo riepiloghi dei subagent;
- aprire un file una seconda volta solo se è cambiato o serve una porzione precisa.
