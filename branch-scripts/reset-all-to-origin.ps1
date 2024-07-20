# file name: reset-all-to-origin.ps1

$BranchIndexNumber = "        ";
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

$RefinedBranchIndexNumber | ForEach-Object { $_ } {
    git checkout -b $_;
    git checkout $_  --set-upstream origin/$_;
    git reset --hard origin/$_;
}
