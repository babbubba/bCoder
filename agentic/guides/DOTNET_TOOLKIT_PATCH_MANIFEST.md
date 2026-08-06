# Patch manifest — DeepSeek .NET 10 toolkit

Baseline verificata: `bCoder.zip` allegato il 6 agosto 2026.

## File esistenti sostituiti

- `.github/copilot-instructions.md` — SHA-256 baseline: `4bdabe8061928a51983d87b81f20afdcf691a85bddcfe39210fada341c31ddb7`
- `.github/instructions/csharp.instructions.md` — SHA-256 baseline: `b706c40940fad4df9fdfa50051494ea03254f53bd002be371d2c1eabdd9cc285`
- `.github/agents/implementer.agent.md` — SHA-256 baseline: `018476a8fa85202b5e5bd4d972d89bfa0f422f1779cfe53b3d0590d6b6ea7f8b`
- `.github/agents/reviewer.agent.md` — SHA-256 baseline: `c6a76f627df2889a6476e12aff14fc3e20ed29d0edc0ad4578526446b831c820`
- `.github/agents/project-runner.agent.md` — SHA-256 baseline: `dafc9b636836e89f18605beaf1f0258dd8d387840077d03e9ae8a4f63e4479f8`

## File aggiunti

- `.github/agents/dotnet-diagnostician.agent.md`
- `.github/agents/powershell-diagnostician.agent.md`
- `.github/instructions/msbuild.instructions.md`
- `.github/instructions/powershell.instructions.md`
- `.github/prompts/diagnose-dotnet.prompt.md`
- `.github/prompts/diagnose-powershell.prompt.md`
- `.github/skills/dotnet-api-grounding/SKILL.md`
- `.github/skills/dotnet-api-grounding/resources/csharp14-verification.md`
- `.github/skills/dotnet-api-grounding/scripts/Get-DotNetApiContext.ps1`
- `.github/skills/dotnet-build-diagnostics/SKILL.md`
- `.github/skills/dotnet-build-diagnostics/resources/common-build-failures.md`
- `.github/skills/dotnet-build-diagnostics/scripts/Get-DotNetEnvironment.ps1`
- `.github/skills/dotnet-build-diagnostics/scripts/Invoke-DotNetBuildDiagnostics.ps1`
- `.github/skills/dotnet-implementation-loop/SKILL.md`
- `.github/skills/dotnet-implementation-loop/scripts/Invoke-DotNetVerification.ps1`
- `.github/skills/dotnet-reference-forensics/SKILL.md`
- `.github/skills/dotnet-reference-forensics/resources/reference-layers.md`
- `.github/skills/dotnet-reference-forensics/scripts/Inspect-DotNetReferences.ps1`
- `.github/skills/powershell-safe-debugging/SKILL.md`
- `.github/skills/powershell-safe-debugging/resources/quoting-and-interpolation.md`
- `.github/skills/powershell-safe-debugging/scripts/Test-PowerShellScript.ps1`
- `agentic/guides/DOTNET_DEEPSEEK_TOOLKIT.md`

## File deliberatamente non modificati

- `agentic/tasks/**` e `agentic/tasks/INDEX.md`
- `agentic/runner/STATE.md` e report di esecuzione
- `Directory.Build.props` (è già configurato per `net10.0`, nullable, warnings-as-errors e analyzer)
- `scripts/verify.ps1` (è già il gate completo del repository)
- codice sotto `src/` e `tests/`
- `.env`, `.env.example`, `.git/` e configurazioni utente
