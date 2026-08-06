---
name: PowerShell correctness and diagnostics
description: Regole per script e comandi PowerShell affidabili, inclusi quoting, processi esterni e diagnostica .NET.
applyTo: "**/*.{ps1,psm1,psd1}"
---

- Identifica prima la shell corrente: Windows PowerShell 5.1 o PowerShell 7 (`pwsh`). Non assumere compatibilità implicita.
- Non avviare `powershell.exe -Command` da una sessione PowerShell salvo test cross-version esplicito.
- Evita doppi livelli di quoting. In una stringa con doppi apici la shell chiamante espande `$_`, `$variabile` e subexpression prima della shell figlia.
- Per comandi complessi usa direttamente uno script block o crea un file `.ps1` temporaneo controllato.
- Usa `Set-StrictMode -Version Latest`, `$ErrorActionPreference = 'Stop'` e controlla `$LASTEXITCODE` dopo ogni eseguibile esterno.
- Passa gli argomenti degli eseguibili esterni come array; non costruire comandi concatenando input non attendibile.
- Usa `-LiteralPath` quando il path non contiene wildcard intenzionali.
- Per leggere assembly usa `Resolve-Path` e ricorda che `GetReferencedAssemblies()` mostra metadata emesso, non il grafo MSBuild.
- Prima di dichiarare corretto uno script, esegui il parser PowerShell e PSScriptAnalyzer quando installato.
