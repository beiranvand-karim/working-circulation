$branch = git rev-parse --abbrev-ref HEAD
$commits = git log "${branch}..master" --oneline

if (-not $commits) {
    Write-Host "No commits in master that are missing from '$branch'."
    exit 0
}

Write-Host "Commits in master not in '${branch}':"
$commits | ForEach-Object { Write-Host "  $_" }

$hashes = $commits | ForEach-Object { ($_ -split ' ')[0] }
[array]::Reverse($hashes)

Write-Host "`nCherry-picking $($hashes.Count) commit(s) onto '$branch'..."
foreach ($hash in $hashes) {
    git cherry-pick $hash
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Cherry-pick failed at $hash. Resolve conflicts then run 'git cherry-pick --continue'."
        exit 1
    }
}

Write-Host "Done."
