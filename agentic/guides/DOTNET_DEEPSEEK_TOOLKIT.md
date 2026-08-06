# DeepSeek .NET 10 toolkit

Questo toolkit integra le personalizzazioni esistenti senza duplicare il runner o i task.

## Componenti

### Istruzioni automatiche

- `.github/instructions/csharp.instructions.md` — C# 14/.NET 10.
- `.github/instructions/msbuild.instructions.md` — SDK, MSBuild e riferimenti.
- `.github/instructions/powershell.instructions.md` — PowerShell.

### Skill on demand

- `/dotnet-reference-forensics`
- `/dotnet-build-diagnostics`
- `/dotnet-api-grounding`
- `/powershell-safe-debugging`
- `/dotnet-implementation-loop`

Le skill diagnostiche usano `context: fork`, così l'indagine non riempie la sessione principale. Abilitare:

```json
{
  "github.copilot.chat.skillTool.enabled": true
}
```

### Agenti read-only

- `DotNet Diagnostician`
- `PowerShell Diagnostician`

Prompt manuali:

```text
/diagnose-dotnet project=... problem=...
/diagnose-powershell target=... error=...
```

## Integrazione con il Project Runner

Il runner esistente viene aggiornato per chiamare automaticamente il diagnostician pertinente quando l'implementer o la validazione segnalano un problema ambiguo. Il diagnostician non modifica file; restituisce root cause ed evidenze all'implementer.

## Controllo in VS Code

Dopo l'estrazione:

1. esegui `Developer: Reload Window`;
2. apri `Chat: Open Customizations`;
3. verifica Agents, Skills e Instructions;
4. apri Diagnostics dalla Chat view e controlla eventuali errori di caricamento;
5. prova `/dotnet-reference-forensics` sul caso del `ProjectReference` inutilizzato.

## Principio operativo

Le skill non aumentano i parametri del modello. Aumentano affidabilità e competenza procedurale imponendo strumenti, classificazioni ed evidenze. Compilatore, MSBuild, analyzer e parser PowerShell restano le fonti di verità.
