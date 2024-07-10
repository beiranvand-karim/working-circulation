# file name: reset-all-to-origin.ps1

20..24 | ForEach-Object {$_} {
    git checkout -b $_;
    git checkout $_  --set-upstream origin/$_;
    git reset --hard origin/$_;
}
