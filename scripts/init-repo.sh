#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$ROOT"

if [ ! -d .git ]; then
  git init
fi

git add .
if ! git diff --cached --quiet; then
  if git config user.name >/dev/null && git config user.email >/dev/null; then
    git commit -m "chore: initialize agent orchestrator repository"
  else
    echo "Files staged, but no commit was created because Git user.name/user.email are not configured."
  fi
fi

echo "Repository initialized. Start with agentic/tasks/TASK-001-repository-bootstrap.md"
