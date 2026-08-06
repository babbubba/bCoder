---
name: C# 14 and .NET 10 standards
description: Regole evidence-first per implementazione, diagnosi e review di codice C# su .NET 10.
applyTo: "**/*.cs"
---

- Il target del repository è .NET 10. Usa funzionalità C# 14 solo quando `LangVersion` e SDK effettivi le consentono.
- Prima di usare un'API non già presente nel repository, cercane la definizione nelle reference assembly, nei package risolti o verifica con una compilazione minima.
- Non correggere errori con cast, `dynamic`, reflection, `!`, `#pragma` o soppressioni analyzer senza identificare la causa.
- Per errori di simboli distingui parsing, binding, reference del compilatore, metadata emesso e caricamento runtime.
- Mantieni nullable reference types corretti; non silenziare warning senza una motivazione verificabile.
- Propaga `CancellationToken` nelle operazioni asincrone e non bloccare async con `.Result`, `.Wait()` o `GetAwaiter().GetResult()` nel normale codice applicativo.
- Preferisci record e value object immutabili nel Domain quando coerente con le invarianti.
- Usa dependency injection ai confini utili; evita service locator e singleton con stato mutabile.
- Usa Problem Details all'esterno ed errori/domain result tipizzati all'interno.
- Compila il progetto coinvolto dopo ogni incremento coerente; non accumulare modifiche prima della prima build.
- Scrivi test per happy path, failure path, cancellazione e concorrenza quando pertinenti.
