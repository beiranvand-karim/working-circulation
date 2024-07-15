# file name: remove-all-branches-local.ps1

$BranchIndexNumber = "        ";
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

git checkout master;

$RefinedBranchIndexNumber | ForEach-Object { $_ } {
    git branch -D $_;
}
