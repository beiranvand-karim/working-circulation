# file name: rebase-only-one-to-master.ps1

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$ThisScriptParent = Split-Path -Path $ThisScript -Parent;
$ThisScriptGrandParent = Split-Path -Path $ThisScriptParent -Parent;
$JsonFileContent = Join-Path -Path $ThisScriptGrandParent -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$BranchIndexNumber = $json.BranchIndexNumber;
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();


$RefinedBranchIndexNumber | ForEach-Object { $_ } {
    git branch -u origin/$_ $_;
}