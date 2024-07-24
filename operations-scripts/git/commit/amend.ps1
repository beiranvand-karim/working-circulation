# file name: amend.ps1

$thisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$jsonData1 = Join-Path -Path $thisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $jsonData1 -Raw | ConvertFrom-Json;

$CommitIndexNumber = $json.CommitIndexNumber;
$BranchIndexNumber = $json.BranchIndexNumber;

$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();


$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
    git add .
    git commit -m "$RefinedBranchIndexNumber";
}