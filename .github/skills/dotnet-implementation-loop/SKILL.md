---
name: dotnet-implementation-loop
description: Applica un ciclo di implementazione C#/.NET 10 rapido e verificabile: modifica minima, build precoce, test mirati, formatter e gate completo. Usare durante normali task di coding .NET per ridurre errori accumulati e tentativi casuali.
argument-hint: "[task-or-project-path]"
---

# .NET implementation loop

Questa skill guida l'implementazione nel contesto corrente.

## Ciclo

1. Identifica progetto e test direttamente coinvolti.
2. Formula un piano di massimo cinque punti.
3. Fai il primo incremento minimo e coerente.
4. Compila subito il progetto interessato.
5. Correggi il primo errore reale, non errori ipotetici successivi.
6. Esegui test mirati.
7. Esegui il gate completo tramite `scripts/verify.ps1` se presente; altrimenti usa [Invoke-DotNetVerification.ps1](./scripts/Invoke-DotNetVerification.ps1).
8. Revisiona il diff per scope creep, API inventate, soppressioni, nullable e failure path.

## Escalation

- riferimenti/assembly: `dotnet-reference-forensics`;
- build/MSBuild/package/analyzer: `dotnet-build-diagnostics`;
- API o C# 14 dubbia: `dotnet-api-grounding`;
- PowerShell: `powershell-safe-debugging`.

Non continuare a modificare quando la root cause è incerta.
