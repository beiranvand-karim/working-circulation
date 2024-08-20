# file name: create-branch-with-commit.ps1

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$ThisScriptParent = Split-Path -Path $ThisScript -Parent;
$JsonFileContent = Join-Path -Path $ThisScriptParent -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$BranchIndexNumber = $json.BranchIndexNumber;
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

$RefinedBranchIndexNumber | ForEach-Object { $_ } {
    git checkout -b $_;
    git add .;
    git commit -m "$_";
    git push --set-upstream origin $_;
}
