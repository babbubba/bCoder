# Livelli dei riferimenti .NET

| Livello | Domanda | Strumento principale |
|---|---|---|
| Dichiarazione | Il riferimento è scritto nel progetto? | lettura `.csproj` |
| Valutazione | La `Condition` lo include davvero? | `dotnet msbuild -getItem:ProjectReference` |
| Compilazione | Il compilatore riceve la reference? | binary log MSBuild / diagnostic build |
| Emit | Il metadata finale contiene `AssemblyRef`? | `Assembly.GetReferencedAssemblies()` o metadata reader |
| Output | La DLL viene copiata? | directory output e copy-local rules |
| Runtime | La dipendenza è risolta/caricata? | `.deps.json`, host tracing, runtime logs |

## Errore comune

`GetReferencedAssemblies()` interroga il metadata già emesso. Non elenca tutti i `ProjectReference` dichiarati e non dimostra da solo cosa MSBuild abbia valutato.

## Uso effettivo che normalmente forza una reference

- tipo in una firma pubblica o privata;
- classe base o interfaccia;
- attributo;
- parametro generico;
- istanziazione o accesso a membri;
- enum o costante che richieda metadata del tipo.
