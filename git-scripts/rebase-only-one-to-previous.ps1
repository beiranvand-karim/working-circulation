# file name: rebase-only-one-to-previous.ps1

$BranchIndexNumber = "        ";
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

$RefinedBranchIndexNumber  | ForEach-Object { $_ } {
    $current_branch = ($_ - 0);
    $previous_branch = ($_ - 1);
    git rebase $previous_branch $current_branch;
    git push -f --set-upstream origin $current_branch;
}