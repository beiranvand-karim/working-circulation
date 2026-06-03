# file name: cherry-pick top .ps1

$current_branch = (git branch --show-current | Out-String).Split("`n") -join "" | ForEach-Object { $_.Replace("`r", "") }
$temp10min_branch = "$current_branch-temp10min"
$top_commit = git log $temp10min_branch -1 --format="%H"
git cherry-pick $top_commit
