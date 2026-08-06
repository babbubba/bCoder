# Checklist di verifica C# 14 / .NET 10

- Confermare SDK con `dotnet --version` e `dotnet --list-sdks`.
- Leggere `TargetFramework`, `TargetFrameworks` e `LangVersion` valutati, non solo il testo XML.
- Distinguere funzionalità del linguaggio da API della BCL.
- Una funzionalità C# può dipendere dal compilatore; una API dipende dalle reference assembly/package.
- Compilare un esempio minimo con lo stesso SDK e proprietà del progetto.
- Non usare preview features salvo configurazione esplicita e motivata.
- Non impostare `LangVersion=latest` per mascherare un'incompatibilità.
