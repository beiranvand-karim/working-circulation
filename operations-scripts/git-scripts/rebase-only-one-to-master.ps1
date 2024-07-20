# file name: rebase-only-one-to-master.ps1

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$BranchIndexNumber = $json.BranchIndexNumber;
$RefinedBranchIndexNumber = [int]$BranchIndexNumber.TrimStart().TrimEnd();

$RefinedBranchIndexNumber | ForEach-Object { $_ } {
    $current_branch = ($_ - 0);
    git fetch -f origin master:master;
    git rebase master $current_branch;
    git push -f --set-upstream origin $current_branch;
}