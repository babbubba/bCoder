# Avvio del progetto

## 1. Prerequisiti

- Git.
- .NET SDK 8 o successivo compatibile con la versione scelta di Microsoft Agent Framework.
- Docker e Docker Compose per PostgreSQL e test di integrazione.
- VS Code con GitHub Copilot Chat oppure altro coding agent con tool calling.
- DS4 raggiungibile tramite endpoint OpenAI-compatible.
- Chiave OpenRouter solo quando si implementano i task relativi; non inserirla mai nel repository.

## 2. Inizializzazione

Linux/macOS:

```bash
chmod +x scripts/init-repo.sh
./scripts/init-repo.sh
```

PowerShell:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
./scripts/init-repo.ps1
```

## 3. Primo utilizzo con Copilot

1. Seleziona **DeepSeek V4 Flash Q2 - Fast 32K**.
2. Apri una nuova chat.
3. Esegui `/implement-task` e indica `agentic/tasks/TASK-001-repository-bootstrap.md`.
4. Non eseguire più task nella stessa chat.
5. Al termine usa `/review-task` in una nuova chat.

## 4. Regola 32K/64K

- **32K**: implementazione circoscritta, test, client HTTP, CRUD, documentazione.
- **64K**: architettura, dominio, routing, sicurezza, workflow multi-agente, revisione trasversale.

La scelta è già riportata nel frontespizio di ogni task.

## 5. Definition of Done minima

Un task non è concluso finché non sono disponibili:

- implementazione completa;
- build riuscita;
- test previsti riusciti;
- nessun segreto nei file o nei log;
- `git diff` revisionato;
- aggiornamento della sezione “Esito esecuzione” nel task;
- eventuale ADR creato o aggiornato.
