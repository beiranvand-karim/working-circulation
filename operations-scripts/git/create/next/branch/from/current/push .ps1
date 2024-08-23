# file name: /create/from/current/branch.ps1

$CommandOutput = git log -1 --pretty=%B | Out-String;
$CurrentBranchName = [string]::join("", ($CommandOutput.Split("`n")));
$WindowsRemoveCarriageReturn = $CurrentBranchName.Replace("`r", "");
git push --set-upstream origin $WindowsRemoveCarriageReturn;