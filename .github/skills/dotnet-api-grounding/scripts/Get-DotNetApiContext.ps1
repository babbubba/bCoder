[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $Project
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$resolved = (Resolve-Path -LiteralPath $Project).Path

& dotnet --version
if ($LASTEXITCODE -ne 0) { throw "dotnet --version failed: $LASTEXITCODE" }

& dotnet msbuild $resolved '-getProperty:TargetFramework,TargetFrameworks,LangVersion,EnablePreviewFeatures,Nullable,ImplicitUsings'
if ($LASTEXITCODE -ne 0) { throw "MSBuild property evaluation failed: $LASTEXITCODE" }

& dotnet package list --project $resolved
if ($LASTEXITCODE -ne 0) {
    Write-Warning 'Noun-first package command failed; trying legacy syntax.'
    & dotnet list $resolved package
    if ($LASTEXITCODE -ne 0) { throw "dotnet package list failed: $LASTEXITCODE" }
}
