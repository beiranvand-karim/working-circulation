git checkout master

1..10 | ForEach-Object {$_} {
    $origin = git push -d origin $_
    Write-Host $origin
    $local = git branch -D $_
    Write-Host $local
}
