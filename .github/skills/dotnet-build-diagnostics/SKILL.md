---
name: dotnet-build-diagnostics
description: Diagnostica restore, build, analyzer, target framework, package, generator e MSBuild failures in progetti .NET 10. Usare prima di modificare csproj o sopprimere errori quando la build fallisce o produce risultati incoerenti.
argument-hint: "[project-or-solution-path]"
context: fork
---

# .NET build diagnostics

Non correggere il codice durante l'indagine.

## Procedura

1. Acquisisci l'ambiente con [Get-DotNetEnvironment.ps1](./scripts/Get-DotNetEnvironment.ps1).
2. Riproduci il failure sul progetto più piccolo coinvolto.
3. Classifica: restore, evaluation, compile, source generator, analyzer, test discovery, runtime o tooling.
4. Esegui [Invoke-DotNetBuildDiagnostics.ps1](./scripts/Invoke-DotNetBuildDiagnostics.ps1), che produce log e binary log sotto `artifacts/diagnostics/`.
5. Usa [common failure taxonomy](./resources/common-build-failures.md) per evitare correzioni casuali.
6. Verifica una sola ipotesi per volta con un comando riproducibile.
7. Proponi la modifica minima e i comandi di verifica; non applicarla.

## Divieti

- non cambiare target framework “per provare”;
- non aggiornare/downgradare package senza evidenza;
- non disabilitare analyzer o warnings-as-errors;
- non cancellare cache globali come primo tentativo;
- non attribuire a NuGet un errore di binding C# o viceversa.

## Output

```text
FAILURE_PHASE:
MINIMAL_REPRO_COMMAND:
SDK_AND_MSBUILD:
EVIDENCE_FILES:
PRIMARY_ERROR:
ROOT_CAUSE:
MINIMAL_FIX:
VERIFICATION_COMMANDS:
```
