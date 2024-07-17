# file name: squash-commits-straight.ps1

$CommitIndexNumber = "        ";
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$message = "        "

$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
    $RefinedMessage = $message.TrimStart().TrimEnd();
    git commit -m "$RefinedMessage";
}
