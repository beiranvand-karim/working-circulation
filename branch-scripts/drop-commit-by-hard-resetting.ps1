# file name: drop-commit-by-hard-resetting.ps1

$CommitIndexNumber = "        ";
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --hard HEAD~$_;
}
