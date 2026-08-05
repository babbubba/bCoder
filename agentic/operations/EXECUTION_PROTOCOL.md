# Protocollo di esecuzione

## Input al coder

- task normalizzato;
- criteri di accettazione;
- file pertinenti;
- decisioni architetturali;
- strumenti concessi;
- limiti tentativi e budget.

## Output del coder

- riepilogo modifiche;
- file modificati;
- comandi eseguiti;
- build/test result;
- rischi residui;
- richiesta di escalation, se necessaria.

## Validazione

1. exit code dei comandi;
2. test;
3. analizzatori;
4. verifica acceptance criteria;
5. reviewer indipendente.

## Escalation

Il coder non sceglie direttamente un modello paid. Produce una `DelegationRequest`; il router valuta policy e, se necessario, genera `ApprovalRequest`.
