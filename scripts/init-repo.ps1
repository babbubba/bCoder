$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
Set-Location $Root

if (-not (Test-Path ".git")) {
    git init
}

git add .
$changes = git diff --cached --name-only
if ($changes) {
    $userName = git config user.name
    $userEmail = git config user.email
    if ($userName -and $userEmail) {
        git commit -m "chore: initialize agent orchestrator repository"
    }
    else {
        Write-Warning "Files staged, but no commit was created because Git user.name/user.email are not configured."
    }
}

Write-Host "Repository initialized. Start with agentic/tasks/TASK-001-repository-bootstrap.md"
