---
name: diagnose-dotnet
description: Diagnostica un problema C#/.NET 10/MSBuild in sola lettura prima di modificare codice.
agent: DotNet Diagnostician
argument-hint: project=<path> problem=<errore o comportamento>
---

Diagnostica `${input:problem}` nel progetto `${input:project}`.

Riproduci, classifica il livello, usa la skill specifica e restituisci root cause, evidenze, correzione minima e comandi di verifica. Non modificare file.
