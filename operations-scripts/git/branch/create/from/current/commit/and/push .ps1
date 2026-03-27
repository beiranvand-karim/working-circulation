# file name: /create/from/current/branch.ps1

$CommandOutput = git log -1 --pretty=%B | Out-String;
$CurrentCommitName = [string]::join("", ($CommandOutput.Split("`n")));
$WindowsRemoveCarriageReturn = $CurrentCommitName.Replace("`r", "");
$ConvertToNumber = [int]$WindowsRemoveCarriageReturn;
$NextBranchCommitIndexNumber = ($ConvertToNumber + 1);

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$WorkingDirectory = $json.WorkingDirectory;
Push-Location $WorkingDirectory;

git checkout -b $NextBranchCommitIndexNumber;
git add .;
git commit -m "$NextBranchCommitIndexNumber";
git push --set-upstream origin $NextBranchCommitIndexNumber;

Pop-Location