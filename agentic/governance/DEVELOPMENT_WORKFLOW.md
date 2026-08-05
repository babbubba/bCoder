# Workflow di sviluppo agentico

## Ciclo standard

1. scegliere il primo task `Ready` senza dipendenze aperte;
2. selezionare il profilo 32K/64K indicato;
3. aprire nuova chat;
4. eseguire `/implement-task` indicando il file;
5. approvare solo tool coerenti con il task;
6. verificare build/test e diff;
7. aprire nuova chat con `/review-task`;
8. applicare eventuali correzioni nella sessione implementer;
9. aggiornare stato a `Done`;
10. commit umano.

## Stato task

- `Planned`;
- `Ready`;
- `InProgress`;
- `InReview`;
- `Blocked`;
- `Done`.

## Commit

Formato consigliato:

```text
feat(task-015): implement deterministic model routing
```

## Branch

```text
agent/TASK-015-deterministic-routing
```

## Contesto

Non cambiare modello durante la stessa sessione. Il passaggio 32K/64K va effettuato aprendo una nuova chat; una conversazione già compattata non recupera il contesto perduto.
