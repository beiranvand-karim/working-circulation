git checkout master

1..10 | ForEach-Object {$_} {
    # remote
    git push -d origin $_

    # local
    git branch -D $_
}
