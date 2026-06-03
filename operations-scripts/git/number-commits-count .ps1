$branch = git rev-parse --abbrev-ref HEAD
$commits = git log $branch --oneline
$numberOnly = $commits | Where-Object { $_ -match '^\S+ \d+$' }
$described = $commits | Where-Object { $_ -notmatch '^\S+ \d+$' }

Write-Host "Commits with only a number as title: $($numberOnly.Count)"

$result = [PSCustomObject]@{
    total           = $commits.Count
    numberOnly      = $numberOnly.Count
    withDescription = $described.Count
}

$outputPath = Join-Path $PSScriptRoot "number-commits-count.worker.json"
$result | ConvertTo-Json | Set-Content -Path $outputPath
Write-Host "Results written to: $outputPath"