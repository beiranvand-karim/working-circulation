# file name: remove-all-branches.ps1

$BranchIndexNumber = "        ";
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

git checkout master;

$RefinedBranchIndexNumber  | ForEach-Object { $_ } {
    # remote
    git push -d origin $_;

    # local
    git branch -D $_;
}
