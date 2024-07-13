# file name: drop-commit-by-hard-resetting.ps1

1 | ForEach-Object { $_ } {
    git reset --hard HEAD~$_;
}
