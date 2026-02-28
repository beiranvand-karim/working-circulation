# file name: /create/from/current/branch.ps1

$cmdOutput = git branch --show-current | Out-String
$CurrentBranchName = [string]::join("", ($cmdOutput.Split("`n")))
$CurrentBranchIndexNumber = [int] $CurrentBranchName;
$NextBranchCommitIndexNumber = ($CurrentBranchIndexNumber + 1);

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$WorkingDirectory = $json.WorkingDirectory;

Push-Location $WorkingDirectory

git checkout -b $NextBranchCommitIndexNumber;
git add .;
git commit -m "$NextBranchCommitIndexNumber";

Pop-Location