# Policy di routing dei modelli

## Ordine predefinito

1. **Local manager/coder** — DeepSeek V4 Flash DS4.
2. **Specific free model** — modello `:free` selezionato dal catalogo.
3. **Free router** — `openrouter/free`, solo per task a rischio basso e non sensibili.
4. **Paid economy** — allow-list e soglia di costo.
5. **Frontier** — approvazione esplicita per singolo tentativo.

## Decisione deterministica

Il manager può suggerire capacità e tier, ma `ModelRouter` applica:

- classificazione dati;
- contesto minimo necessario;
- supporto tools/structured output;
- disponibilità;
- prezzo;
- latenza/throughput se disponibili;
- numero di tentativi già falliti;
- budget residuo;
- policy del repository.

## Privacy class

- `Public`: invio esterno consentito.
- `Internal`: provider esterni consentiti solo se policy del repository lo permette.
- `Confidential`: locale per impostazione predefinita; eccezione con approvazione e redazione.
- `Restricted`: esclusivamente locale.

## Regole free-first

- prediligere un modello gratuito specifico con capacità note;
- usare `openrouter/free` solo quando la casualità del modello selezionato è accettabile;
- non considerare un fallback di rete come valutazione della qualità;
- un tentativo gratuito fallito deve essere validato dai quality gate prima di decidere escalation.

## Retry

- massimo due tentativi locali per lo stesso task e stessa strategia;
- secondo tentativo riceve errori di build/test e diff precedente;
- dopo due fallimenti il router rivaluta modello e strategia;
- non superare tre provider esterni per singolo task senza intervento umano.

## Paid e frontier

Richiedono approvazione quando:

- il costo stimato supera la soglia del task;
- il modello è classificato frontier;
- vengono inviati dati Internal o Confidential;
- il task modifica sicurezza, deployment o migrazioni dati;
- i test deterministici non sono disponibili.

## Output della selezione

Ogni decisione deve produrre:

```json
{
  "provider": "ds4|openrouter",
  "model": "model-id",
  "tier": "local|free|paid-economy|frontier",
  "reason": "spiegazione sintetica",
  "estimatedCost": 0,
  "approvalRequired": false,
  "privacyDecision": "allowed|redacted|denied"
}
```
