$numbers = git log -10 --pretty=format:"%s" | ForEach-Object { $_.Trim() } | Where-Object { $_ -match '^\d+$' } | ForEach-Object { [int]$_ }

$numbers | ConvertTo-Json | Set-Content "commit-numbers.json"

Write-Host "Extracted: $($numbers -join ', ')"
