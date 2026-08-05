# Modello di dominio iniziale

## WorkRequest

Richiesta utente di alto livello. Contiene obiettivo, repository, classificazione dati, budget e stato.

## AgentTask

Unità eseguibile. Contiene dipendenze, criteri di accettazione, contesto consigliato, rischio e stato.

## TaskAttempt

Singolo tentativo di un agente/modello. Registra input sintetico, provider, modello, tool call, usage, costo, esito build/test e review.

## ModelDescriptor

Metadati normalizzati: provider, ID, prezzo, context window, tools, structured output, reasoning, disponibilità e tier.

## RoutingDecision

Decisione spiegabile e immutabile per un tentativo.

## ApprovalRequest

Richiesta human-in-the-loop con tipo, motivazione, costo stimato, dati coinvolti e scadenza.

## WorkflowCheckpoint

Stato serializzabile necessario per riprendere l'esecuzione.

## Artifact

Diff, log, report, output test e altri file prodotti dal workflow.
