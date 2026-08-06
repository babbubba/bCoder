[CmdletBinding()]
param(
    [string] $Project = '.'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

Write-Host '=== dotnet --info ===' -ForegroundColor Cyan
& dotnet --info
if ($LASTEXITCODE -ne 0) { throw "dotnet --info failed: $LASTEXITCODE" }

Write-Host '=== dotnet --list-sdks ===' -ForegroundColor Cyan
& dotnet --list-sdks
if ($LASTEXITCODE -ne 0) { throw "dotnet --list-sdks failed: $LASTEXITCODE" }

Write-Host '=== dotnet msbuild -version ===' -ForegroundColor Cyan
& dotnet msbuild -version
if ($LASTEXITCODE -ne 0) { throw "dotnet msbuild failed: $LASTEXITCODE" }

if (Test-Path -LiteralPath $Project -PathType Leaf) {
    $resolved = (Resolve-Path -LiteralPath $Project).Path
    Write-Host "=== evaluated properties: $resolved ===" -ForegroundColor Cyan
    & dotnet msbuild $resolved '-getProperty:TargetFramework,TargetFrameworks,LangVersion,Nullable,ImplicitUsings,RuntimeIdentifier,RuntimeIdentifiers'
    if ($LASTEXITCODE -ne 0) { throw "MSBuild property evaluation failed: $LASTEXITCODE" }
}
