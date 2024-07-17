edit-last-commit.ps1# file name: edit-last-commit.ps1

$CommitIndexNumber = "    1    ";
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
}
