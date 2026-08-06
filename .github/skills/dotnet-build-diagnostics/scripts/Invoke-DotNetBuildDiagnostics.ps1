[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $ProjectOrSolution,

    [ValidateSet('Debug', 'Release')]
    [string] $Configuration = 'Debug',

    [string] $Framework,

    [switch] $NoRestore
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$target = (Resolve-Path -LiteralPath $ProjectOrSolution).Path
$repoRoot = Split-Path -Parent (Split-Path -Parent (Split-Path -Parent (Split-Path -Parent $PSScriptRoot)))
$artifactDirectory = Join-Path $repoRoot 'artifacts/diagnostics'
New-Item -ItemType Directory -Path $artifactDirectory -Force | Out-Null

$timestamp = Get-Date -Format 'yyyyMMdd-HHmmss'
$binlog = Join-Path $artifactDirectory "build-$timestamp.binlog"
$log = Join-Path $artifactDirectory "build-$timestamp.log"

$arguments = @('build', $target, '--configuration', $Configuration, '--no-incremental', '-v:minimal', "-bl:$binlog")
if ($Framework) { $arguments += @('--framework', $Framework) }
if ($NoRestore) { $arguments += '--no-restore' }

Write-Host ("dotnet " + ($arguments -join ' ')) -ForegroundColor Cyan
& dotnet @arguments 2>&1 | Tee-Object -FilePath $log
$exitCode = $LASTEXITCODE

Write-Host "Text log: $log" -ForegroundColor Green
Write-Host "Binary log: $binlog" -ForegroundColor Green

if ($exitCode -ne 0) {
    throw "Build failed with exit code $exitCode"
}
