# file name: squash-commits-straight.ps1

$thisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$ThisScriptParent = Split-Path -Path $ThisScript -Parent;
$JsonFileContent = Join-Path -Path $ThisScriptParent -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$CommitIndexNumber = $json.CommitIndexNumber;
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$message = $json.message;
$RefinedMessage = $message.TrimStart().TrimEnd();

$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
    $RefinedMessage = $message.TrimStart().TrimEnd();
    git commit -m "$RefinedMessage";
}
