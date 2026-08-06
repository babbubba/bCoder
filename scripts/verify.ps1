#verify.ps1 — Single verification command for local build/test pipeline
# Runs: dotnet format --verify-no-changes, dotnet build, dotnet test

$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
Set-Location $root

Write-Host "=== Step 1: dotnet format --verify-no-changes ===" -ForegroundColor Cyan
dotnet format --verify-no-changes
if ($LASTEXITCODE -ne 0) {
    Write-Host "FAIL: dotnet format found formatting issues." -ForegroundColor Red
    exit 1
}
Write-Host "PASS: No formatting issues." -ForegroundColor Green

Write-Host "=== Step 2: dotnet build ===" -ForegroundColor Cyan
dotnet build
if ($LASTEXITCODE -ne 0) {
    Write-Host "FAIL: dotnet build failed." -ForegroundColor Red
    exit 1
}
Write-Host "PASS: Build succeeded." -ForegroundColor Green

Write-Host "=== Step 3: dotnet test ===" -ForegroundColor Cyan
dotnet test
if ($LASTEXITCODE -ne 0) {
    Write-Host "FAIL: dotnet test failed." -ForegroundColor Red
    exit 1
}
Write-Host "PASS: All tests passed." -ForegroundColor Green

Write-Host "=== ALL CHECKS PASSED ===" -ForegroundColor Green
exit 0
