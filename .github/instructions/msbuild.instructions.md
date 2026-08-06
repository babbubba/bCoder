---
name: .NET SDK and MSBuild diagnostics
description: Regole per csproj, props, targets, solution, package e project reference su .NET 10.
applyTo: "**/*.{csproj,props,targets,sln,slnx}"
---

- Distingui sempre: `ProjectReference` dichiarato, item valutato da MSBuild, reference passata al compilatore, `AssemblyRef` emessa, file copiato nell'output e dipendenza caricata a runtime.
- Non usare `Assembly.GetReferencedAssemblies()` per stabilire se un `ProjectReference` esiste nel progetto.
- Per i riferimenti usa prima `dotnet reference list --project <project>`; se necessario usa `dotnet msbuild <project> -getItem:ProjectReference`.
- Controlla `Condition`, `TargetFramework`, `LangVersion`, `ReferenceOutputAssembly`, `PrivateAssets`, configurazione e framework selezionati.
- Un progetto referenziato ma mai usato da tipi, attributi, firme, classi base, interfacce o membri può non comparire come `AssemblyRef` nel metadata finale: non considerarlo automaticamente un errore.
- Per problemi non evidenti genera un binary log con `dotnet build -bl:artifacts/diagnostics/build.binlog --no-incremental`.
- Non modificare un file MSBuild prima di aver mostrato l'evidenza del problema e la proprietà/item effettivamente valutata.
- Non cambiare target framework o versioni package per tentativi casuali.
