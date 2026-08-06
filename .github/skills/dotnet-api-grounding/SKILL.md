---
name: dotnet-api-grounding
description: Verifica che API, overload, opzioni CLI e funzionalità C# 14 siano realmente disponibili nel target .NET 10 e nei package risolti. Usare quando il modello non è sicuro di una API recente o rischia di inventare sintassi, proprietà o metodi.
argument-hint: "[project-path] [api-or-feature]"
context: fork
---

# .NET 10 API grounding

Questa skill verifica, non implementa.

## Ordine delle fonti locali

1. codice e pattern già compilati nel repository;
2. target, `LangVersion` e package valutati da MSBuild;
3. reference assembly dell'SDK e XML documentation locale;
4. NuGet cache locale e metadata del package;
5. progetto minimo temporaneo compilato con lo stesso SDK.

Non dichiarare disponibile una funzionalità solo perché è ricordata dal modello.

## Procedura

1. Esegui [Get-DotNetApiContext.ps1](./scripts/Get-DotNetApiContext.ps1).
2. Cerca l'API nel codice e nei package locali.
3. Per sintassi C# 14 crea una compilazione minima nello spazio temporaneo, senza modificare il repository.
4. Per opzioni CLI usa `dotnet <command> --help` nella versione installata.
5. Riporta esattamente assembly/package/versione o errore di compilazione che prova la conclusione.

Consulta [C# 14 verification checklist](./resources/csharp14-verification.md).

## Output

```text
REQUESTED_API_OR_FEATURE:
TARGET_FRAMEWORK:
LANGUAGE_VERSION:
SDK_VERSION:
LOCAL_EVIDENCE:
MINIMAL_COMPILATION_RESULT:
SUPPORTED: YES | NO | CONDITIONAL | UNKNOWN
CONDITIONS:
SAFE_USAGE_EXAMPLE:
```
