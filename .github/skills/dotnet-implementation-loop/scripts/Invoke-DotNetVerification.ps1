[CmdletBinding()]
param(
    [string] $Target = '.',

    [ValidateSet('Debug', 'Release')]
    [string] $Configuration = 'Debug'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Invoke-Checked {
    param([Parameter(Mandatory)][string[]] $Arguments)
    Write-Host ("dotnet " + ($Arguments -join ' ')) -ForegroundColor Cyan
    & dotnet @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet command failed with exit code $LASTEXITCODE"
    }
}

Invoke-Checked @('format', $Target, '--verify-no-changes')
Invoke-Checked @('build', $Target, '--configuration', $Configuration, '--no-incremental')
Invoke-Checked @('test', $Target, '--configuration', $Configuration, '--no-build')
