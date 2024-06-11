git checkout master

1..10 | ForEach-Object {$_} {
    git branch -D $_
}
