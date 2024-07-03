# file name: rebase-only-one-to-master.ps1

64 | ForEach-Object {$_} {
    $current_branch = ($_ - 0)
    git rebase master $current_branch
    git push -f --set-upstream origin $current_branch
}