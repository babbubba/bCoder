---
name: dotnet-reference-forensics
description: Diagnostica riferimenti mancanti o inattesi tra progetti .NET, assembly compilati e dipendenze runtime. Usare quando un ProjectReference non compare, una DLL non è nell'output, un tipo non viene risolto o GetReferencedAssemblies restituisce risultati inattesi.
argument-hint: "[project-path] [optional-assembly-path]"
context: fork
---

# .NET reference forensics

Non modificare codice o file di progetto durante questa skill.

## Modello mentale obbligatorio

Leggi [reference layers](./resources/reference-layers.md). Classifica la domanda in uno o più livelli:

1. `ProjectReference` dichiarato nel file;
2. item `ProjectReference` valutato da MSBuild;
3. reference passata al compilatore;
4. `AssemblyRef` emessa nel metadata finale;
5. file copiato nell'output;
6. dipendenza registrata in `.deps.json`;
7. assembly caricato a runtime.

Non usare uno strumento di un livello per trarre conclusioni definitive su un altro.

## Procedura

1. Esegui [Inspect-DotNetReferences.ps1](./scripts/Inspect-DotNetReferences.ps1) sul progetto.
2. Verifica `dotnet reference list --project <project>` e `dotnet msbuild <project> -getItem:ProjectReference`.
3. Cerca nel progetto chiamante l'uso effettivo di tipi, attributi, classi base, interfacce, firme, generic type, enum o membri statici del progetto referenziato.
4. Compila con `--no-incremental` e binary log quando la valutazione non è chiara.
5. Solo se è disponibile l'assembly finale, ispeziona `GetReferencedAssemblies()` e `.deps.json`.
6. Confronta le evidenze senza assumere che una DLL inutilizzata debba comparire nel metadata.

## Interpretazione chiave

Un `ProjectReference` può essere correttamente dichiarato e valutato, ma se nessun simbolo del progetto referenziato è necessario nel metadata emesso, l'assembly chiamante può non contenere una `AssemblyRef` verso quella DLL. Questo non prova che il riferimento di progetto sia rotto.

## Output obbligatorio

```text
QUESTION_LAYER:
PROJECT_REFERENCE_DECLARED:
PROJECT_REFERENCE_EVALUATED:
COMPILER_REFERENCE_EVIDENCE:
SYMBOL_USAGE_FOUND:
EMITTED_ASSEMBLY_REFERENCE:
OUTPUT_COPY_STATUS:
DEPS_JSON_STATUS:
ROOT_CAUSE:
MINIMAL_FIX:
VERIFICATION:
```
