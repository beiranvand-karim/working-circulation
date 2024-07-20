# file name: rebase-only-one-to-master.ps1

$BranchIndexNumber = "        ";
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

$RefinedBranchIndexNumber | ForEach-Object { $_ } {
    $current_branch = ($_ - 0);
    git fetch -f origin master:master;
    git rebase master $current_branch;
    git push -f --set-upstream origin $current_branch;
}