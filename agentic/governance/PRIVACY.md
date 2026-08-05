# Classificazione dati e privacy

## Classi

### Public

Codice open source e documentazione pubblica. Provider esterni consentiti secondo budget.

### Internal

Codice interno non sensibile. Provider esterni solo se il repository lo consente e il contesto è minimizzato.

### Confidential

Logica proprietaria, configurazioni cliente, dati operativi. Locale per impostazione predefinita; invio esterno solo con approvazione, redazione e motivazione.

### Restricted

Segreti, dati personali, credenziali, dump, chiavi, configurazioni production. Non deve mai essere inviato a provider esterni.

## Default

Ogni repository è `Internal` finché non viene esplicitamente classificato. Ogni file corrispondente a pattern sensibili viene elevato a `Restricted`.

## Pattern minimi da redigere

- `.env`, secrets e credential files;
- connection strings;
- token, API key e certificati;
- dati cliente;
- dump database;
- log con PII;
- file di configurazione production.
