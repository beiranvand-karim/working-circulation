$branchNumber = [int](git branch --show-current)

$numbers = git log -10 --pretty=format:"%s" |
    ForEach-Object { $_.Trim() } |
    Where-Object { $_ -match '^\d+$' } |
    ForEach-Object { [int]$_ }

return ($numbers | Where-Object { $_ -gt $branchNumber }).Count -gt 0
