# Configurazione VS Code per esecuzione autonoma

## Prerequisiti

- VS Code aggiornato con supporto a custom agents, subagents e Autopilot.
- DeepSeek DGX configurato come Custom Endpoint.
- `ds4-server` disponibile e stabile con almeno 64K di contesto.
- Repository aperto in una branch o worktree dedicata.

## Avvio

1. Apri Chat.
2. Seleziona l’agente `Project Runner`.
3. Seleziona `DeepSeek V4 Flash Q2 - Long 64K`.
4. Verifica che il tool `agent/runSubagent` sia disponibile.
5. Seleziona il permission level `Autopilot`.
6. Esegui `/run-project`.

Non è necessario cambiare modello tra i task. I budget 32K/64K sono applicati dalle istruzioni e dai context package.

## Impostazioni utili

Abilita i subagent e, se disponibili nella tua versione, gli hook degli agenti. I subagent annidati non sono necessari e dovrebbero restare disabilitati.

Esempio facoltativo:

```json
{
  "chat.subagents.allowInvocationsFromSubagents": false,
  "chat.useCustomAgentHooks": true
}
```

Il permission level Autopilot si seleziona dall’interfaccia della sessione. Non abilitarlo globalmente per tutti i workspace.

## Sistema operativo

Durante il run:

- impedisci sospensione e ibernazione del PC;
- lascia VS Code aperto;
- mantieni raggiungibile il DGX;
- evita aggiornamenti o riavvii automatici;
- non modificare manualmente la stessa worktree.
