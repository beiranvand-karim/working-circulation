# file name: hard-reset.ps1

1 | ForEach-Object { $_ } {
    git reset --hard HEAD~$_;
}
