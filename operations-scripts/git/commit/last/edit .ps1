# file name: edit.ps1

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$ThisScriptParent = Split-Path -Path $ThisScript -Parent;
$ThisScriptGrandParent = Split-Path -Path $ThisScriptParent -Parent;
$JsonFileContent = Join-Path -Path $ThisScriptGrandParent -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$CommitIndexNumber = $json.CommitIndexNumber;
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
}
