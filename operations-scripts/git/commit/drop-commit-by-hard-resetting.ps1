# file name: drop-commit-by-hard-resetting.ps1

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$ThisScriptParent = Split-Path -Path $ThisScript -Parent;
$JsonFileContent = Join-Path -Path $ThisScriptParent -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$CommitIndexNumber = $json.CommitIndexNumber;
$RefinedCommitIndexNumber = [int]$CommitIndexNumber.TrimStart().TrimEnd();

$RefinedCommitIndexNumber | ForEach-Object { $_ } {
    git reset --hard HEAD~$_;
}
