$branchNumber = [int](git branch --show-current)

$numbers = git log -10 --pretty=format:"%s" |
    ForEach-Object { $_.Trim() } |
    Where-Object { $_ -match '^\d+$' } |
    ForEach-Object { [int]$_ }

$bigger = $numbers | Where-Object { $_ -gt $branchNumber }

if ($bigger) {
    Write-Host "Commits bigger than branch $branchNumber`:"
    $bigger | ForEach-Object { Write-Host $_ }
} else {
    Write-Host "No commits bigger than branch $branchNumber"
}
