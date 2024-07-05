# file name: remove-all-branches-local.ps1

git checkout master;

1..10 | ForEach-Object {$_} {
    git branch -D $_;
}
