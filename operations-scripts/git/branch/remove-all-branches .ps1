# file name: remove-all-branches.ps1

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$ThisScriptParent = Split-Path -Path $ThisScript -Parent;
$JsonFileContent = Join-Path -Path $ThisScriptParent -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$BranchIndexNumber = $json.BranchIndexNumber;
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

git checkout master;

$RefinedBranchIndexNumber  | ForEach-Object { $_ } {
    # remote
    git push -d origin $_;

    # local
    git branch -D $_;
}
