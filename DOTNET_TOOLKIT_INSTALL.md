# Installazione overlay DeepSeek .NET 10

Questo ZIP contiene percorsi relativi alla root del repository ed è stato costruito confrontandolo con il `bCoder.zip` allegato.

## Prima dell'estrazione

```powershell
git status
git add .
git commit -m "chore: checkpoint before dotnet toolkit"
```

## Applicazione

Estrarre lo ZIP nella root del repository consentendo la sovrascrittura dei file omonimi.

```powershell
Expand-Archive `
    -Path .\bCoder-dotnet-skills-agents-patch.zip `
    -DestinationPath . `
    -Force
```

Poi:

```powershell
git status --short
git diff -- .github agentic DOTNET_TOOLKIT_INSTALL.md
```

## Verifica VS Code

1. `Developer: Reload Window`.
2. Abilitare `github.copilot.chat.skillTool.enabled` per le skill con `context: fork`.
3. Aprire `Chat: Open Customizations` e verificare 5 skill, 2 nuovi agenti e 2 nuove istruzioni.
4. Dalla Chat view aprire `Diagnostics` e controllare che non vi siano errori.
5. Eseguire `/dotnet-reference-forensics` come smoke test.

Per dettagli: `agentic/guides/DOTNET_DEEPSEEK_TOOLKIT.md`.
