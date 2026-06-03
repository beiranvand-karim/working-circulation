$branch = git rev-parse --abbrev-ref HEAD

Write-Host "Rebasing '$branch' onto master..."
git rebase master

if ($LASTEXITCODE -ne 0) {
    Write-Host "Rebase failed. Resolve conflicts then run 'git rebase --continue'."
    exit 1
}

Write-Host "Done. '$branch' is now rebased onto master."
