# file name: drop-commit-by-index.ps1

2 | ForEach-Object {$_} {
    git rebase -i HEAD~${_}
}
