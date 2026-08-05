---
name: CSharp standards
description: Regole per codice C# e progetti .NET.
applyTo: "**/*.cs"
---

- Abilita nullable e implicit usings.
- Preferisci record/value object immutabili nel dominio.
- Propaga CancellationToken.
- Non bloccare async con `.Result` o `.Wait()`.
- Usa dependency injection e interfacce solo ai confini utili.
- Evita service locator e singleton con stato mutabile.
- Usa Problem Details all'esterno ed eccezioni/domain result tipizzati all'interno.
- Scrivi test per happy path, failure path e cancellazione dove pertinente.
