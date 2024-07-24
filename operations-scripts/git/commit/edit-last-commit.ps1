# file name: edit-last-commit.ps1

$thisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$jsonData1 = Join-Path -Path $thisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $jsonData1 -Raw | ConvertFrom-Json;

$CommitIndexNumber = $json.CommitIndexNumber;
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
}
