[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $Path
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$resolved = (Resolve-Path -LiteralPath $Path).Path
$files = if (Test-Path -LiteralPath $resolved -PathType Container) {
    Get-ChildItem -LiteralPath $resolved -Recurse -File -Include *.ps1, *.psm1, *.psd1
}
else {
    Get-Item -LiteralPath $resolved
}

$hasErrors = $false
foreach ($file in $files) {
    $tokens = $null
    $parseErrors = $null
    [void][System.Management.Automation.Language.Parser]::ParseFile(
        $file.FullName,
        [ref] $tokens,
        [ref] $parseErrors
    )

    if ($parseErrors.Count -gt 0) {
        $hasErrors = $true
        Write-Host "Parse errors: $($file.FullName)" -ForegroundColor Red
        $parseErrors | Format-Table Message, Extent -AutoSize
    }
    else {
        Write-Host "Parse OK: $($file.FullName)" -ForegroundColor Green
    }
}

if (Get-Command Invoke-ScriptAnalyzer -ErrorAction SilentlyContinue) {
    $analyzerArguments = @{
        Path = $resolved
        Severity = @('Error', 'Warning')
    }
    if (Test-Path -LiteralPath $resolved -PathType Container) {
        $analyzerArguments.Recurse = $true
    }
    $findings = Invoke-ScriptAnalyzer @analyzerArguments
    if ($findings) {
        $hasErrors = $true
        $findings | Format-Table RuleName, Severity, ScriptName, Line, Message -AutoSize
    }
    else {
        Write-Host 'PSScriptAnalyzer: no findings.' -ForegroundColor Green
    }
}
else {
    Write-Warning 'PSScriptAnalyzer is not installed; only parser validation was performed.'
}

if ($hasErrors) { exit 1 }
exit 0
