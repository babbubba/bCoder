# Quality gates

## Gate obbligatori per ogni task

1. requisiti del task coperti;
2. build riuscita;
3. test pertinenti riusciti;
4. formatter e analizzatori senza errori bloccanti;
5. nessun segreto rilevato;
6. diff limitato al perimetro;
7. documentazione aggiornata;
8. esito registrato nel task.

## Ordine di valutazione

I segnali deterministici prevalgono sul giudizio LLM:

```text
compile > test > static analysis > acceptance checks > reviewer LLM
```

Un reviewer non può approvare codice che non compila, salvo task esplicitamente documentale.

## Review indipendente

La review deve avvenire in una sessione nuova. Il reviewer riceve:

- task;
- diff;
- output build/test;
- ADR e policy rilevanti;
- rischi dichiarati dal coder.

## Esiti

- `Approved`;
- `ApprovedWithNotes`;
- `ChangesRequested`;
- `Blocked`;
- `EscalationRequired`.

## Quality gate di rilascio MVP

- test unitari e integrazione verdi;
- scenari E2E locali verdi;
- scenario approval paid verificato;
- threat model aggiornato;
- nessun finding critico;
- runbook di deployment provato da ambiente pulito.
