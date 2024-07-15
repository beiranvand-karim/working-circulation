# file name: create-branch-with-commit.ps1

$BranchIndexNumber = "        ";
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

$RefinedBranchIndexNumber | ForEach-Object { $_ } {
    git checkout -b $_;
    git add .;
    git commit -m "$_";
    git push --set-upstream origin $_;
}
