$current_branch = (git branch --show-current | Out-String).Split("`n") -join "" | ForEach-Object { $_.Replace("`r", "") }
git reset --hard origin/$current_branch