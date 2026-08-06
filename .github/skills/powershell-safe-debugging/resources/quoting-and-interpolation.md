# Quoting e interpolazione PowerShell

## Regola essenziale

Le stringhe con doppi apici espandono variabili e subexpression. Le stringhe con apici singoli sono letterali.

Esempio fragile in una sessione PowerShell:

```powershell
powershell -Command "Get-Process | ForEach-Object { $_.Name }"
```

La shell chiamante può espandere `$_`, consegnando alla shell figlia `{ .Name }`.

Preferire l'esecuzione diretta:

```powershell
Get-Process | ForEach-Object { $_.Name }
```

Se è indispensabile una shell figlia, usare una stringa letterale e verificare le virgolette interne:

```powershell
powershell -NoProfile -Command 'Get-Process | ForEach-Object { $_.Name }'
```

## Eseguibili esterni

```powershell
& dotnet @arguments
if ($LASTEXITCODE -ne 0) {
    throw "dotnet failed: $LASTEXITCODE"
}
```
