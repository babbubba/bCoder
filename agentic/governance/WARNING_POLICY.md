# Build Warning Policy

## Regola generale

**Tutti gli avvisi di compilazione sono trattati come errori**  
(`TreatWarningsAsErrors=true` in `Directory.Build.props`).

## Eccezioni esplicite

| Warning ID | Motivo | Documentato in |
|---|---|---|
| `CS1591` | I progetti placeholder non hanno ancora commenti XML pubblici completi. Soppresso globalmente. | `Directory.Build.props` `<NoWarn>$(NoWarn);CS1591</NoWarn>` |

## Regole IDE/analyser

Tutti i diagnostic IDE con gravità `warning` in `.editorconfig` sono anch'essi trattati come errori grazie a `TreatWarningsAsErrors=true` e `EnforceCodeStyleInBuild=true`.

Le regole di stile (`csharp_style_*`, `dotnet_style_*`) sono abilitate e applicate da `dotnet format`.

## Pipeline di verifica

Eseguire `scripts\verify.ps1` per la verifica completa:
1. `dotnet format --verify-no-changes` — controllo stile e formattazione.
2. `dotnet build` — compilazione con zero avvisi/errori.
3. `dotnet test` — test runner xUnit.

## Aggiungere una nuova eccezione

Se un nuovo warning ID deve essere soppresso:
- Aggiungere l'ID a `<NoWarn>` in `Directory.Build.props`.
- Documentare ID, motivo e responsabile in questa tabella.
- Se riguarda solo un progetto, usare una proprietà `<NoWarn>` locale in quel `.csproj` invece di quella globale.
