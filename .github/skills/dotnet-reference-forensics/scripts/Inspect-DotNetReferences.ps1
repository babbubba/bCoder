[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $Project,

    [string] $AssemblyPath,

    [ValidateSet('Debug', 'Release')]
    [string] $Configuration = 'Debug',

    [string] $Framework,

    [switch] $Build
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Invoke-DotNet {
    param([Parameter(Mandatory)][string[]] $Arguments)

    Write-Host ("dotnet " + ($Arguments -join ' ')) -ForegroundColor Cyan
    & dotnet @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet command failed with exit code $LASTEXITCODE"
    }
}

$resolvedProject = (Resolve-Path -LiteralPath $Project).Path
Write-Host "Project: $resolvedProject" -ForegroundColor Green

Invoke-DotNet @('--version')

try {
    Invoke-DotNet @('reference', 'list', '--project', $resolvedProject)
}
catch {
    Write-Warning "Noun-first command failed; trying legacy syntax. $($_.Exception.Message)"
    Invoke-DotNet @('list', $resolvedProject, 'reference')
}

Invoke-DotNet @(
    'msbuild',
    $resolvedProject,
    '-getItem:ProjectReference',
    '-getProperty:TargetFramework,TargetFrameworks,LangVersion,OutputPath,AssemblyName'
)

if ($Build) {
    $repoRoot = Split-Path -Parent (Split-Path -Parent (Split-Path -Parent (Split-Path -Parent $PSScriptRoot)))
    $artifactDirectory = Join-Path $repoRoot 'artifacts/diagnostics'
    New-Item -ItemType Directory -Path $artifactDirectory -Force | Out-Null
    $binlog = Join-Path $artifactDirectory 'reference-forensics.binlog'

    $arguments = @('build', $resolvedProject, '--configuration', $Configuration, '--no-incremental', "-bl:$binlog", '-v:minimal')
    if ($Framework) {
        $arguments += @('--framework', $Framework)
    }
    Invoke-DotNet $arguments
    Write-Host "Binary log: $binlog" -ForegroundColor Green
}

if ($AssemblyPath) {
    $resolvedAssembly = (Resolve-Path -LiteralPath $AssemblyPath).Path
    Write-Host "Assembly metadata references: $resolvedAssembly" -ForegroundColor Green
    $assembly = [System.Reflection.Assembly]::LoadFrom($resolvedAssembly)
    $assembly.GetReferencedAssemblies() |
        Sort-Object Name |
        Select-Object Name, Version, CultureName |
        Format-Table -AutoSize

    $depsPath = [System.IO.Path]::ChangeExtension($resolvedAssembly, '.deps.json')
    if (Test-Path -LiteralPath $depsPath) {
        Write-Host "deps.json: $depsPath" -ForegroundColor Green
    }
    else {
        Write-Host 'No adjacent deps.json found.' -ForegroundColor Yellow
    }
}
else {
    Write-Host 'AssemblyPath not supplied; metadata emit was not inspected.' -ForegroundColor Yellow
}
