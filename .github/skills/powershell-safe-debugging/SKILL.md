---
name: powershell-safe-debugging
description: Diagnostica e corregge in modo evidence-first script e comandi PowerShell, soprattutto quoting, interpolazione di $_ e variabili, processi esterni, path, exit code e differenze Windows PowerShell/pwsh.
argument-hint: "[script-path-or-command]"
context: fork
---

# PowerShell safe debugging

Non modificare lo script finché non hai riprodotto e classificato il problema.

## Procedura

1. Rileva `$PSVersionTable`, edition e host.
2. Se il problema è un comando inline, trasformalo in uno script block minimo nella stessa shell; non annidare `powershell -Command`.
3. Leggi [quoting and interpolation](./resources/quoting-and-interpolation.md).
4. Per un file esegui [Test-PowerShellScript.ps1](./scripts/Test-PowerShellScript.ps1).
5. Distingui parse error, parameter binding, runtime exception ed exit code di un eseguibile esterno.
6. Proponi la correzione minima e un test sia per Windows PowerShell 5.1 sia per pwsh quando il repository richiede compatibilità.

## Regole

- `$_` dentro una stringa a doppi apici può essere espanso dalla shell chiamante.
- `$ErrorActionPreference = 'Stop'` non converte automaticamente in eccezione un exit code non zero di `dotnet` o `git`: controlla `$LASTEXITCODE`.
- Non usare `Invoke-Expression`.
- Non concatenare input non attendibile in una command line.

## Output

```text
SHELL:
FAILURE_CLASS:
MINIMAL_REPRODUCTION:
PARSE_RESULT:
ROOT_CAUSE:
CORRECTED_FORM:
VALIDATION:
CROSS_VERSION_NOTES:
```
