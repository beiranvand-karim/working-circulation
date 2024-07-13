# file name: squash-commits-straight.ps1

$message = "        "

3 | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
    $RefinedMessage = $message.TrimStart().TrimEnd();
    git commit -m "$RefinedMessage";
}
