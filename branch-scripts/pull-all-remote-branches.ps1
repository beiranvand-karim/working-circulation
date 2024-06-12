
61..63 | ForEach-Object {$_} {
    $local = "git fetch -f origin ${_}:${_}"
    Write-Host $local
}
