# file name: drop-commit-by-index.ps1

$CommitIndexNumber = "        ";
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$RefinedCommitIndexNumber  | ForEach-Object { $_ } {
    git rebase -i HEAD~$_;
}
