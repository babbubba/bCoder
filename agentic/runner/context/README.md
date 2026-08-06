# Context package per task

Ogni file `TASK-XXX.md` definisce la lista chiusa dei documenti e delle aree di codice autorizzate per implementazione e review.

## Precedenza

Questi package prevalgono sulle istruzioni legacy nei task che chiedono di leggere genericamente molti documenti.

## Uso

- Il Project Runner legge solo il package del task corrente.
- Il Task Implementer e il Task Reviewer ricevono il percorso del package.
- I documenti elencati devono essere letti solo nelle sezioni indicate.
- I documenti non elencati non vanno aperti “per completezza”.
- Il budget 32K/64K è operativo; in modalità autonoma il modello selezionato resta Long 64K.
