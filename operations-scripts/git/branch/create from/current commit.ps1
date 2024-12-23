# file name: /create/from/current/branch.ps1

$CommandOutput = git log -1 --pretty=%B | Out-String;
$CurrentBranchName = [string]::join("", ($CommandOutput.Split("`n")));
$WindowsRemoveCarriageReturn = $CurrentBranchName.Replace("`r", "");
$ConvertToNumber = [int]$WindowsRemoveCarriageReturn;
$NextBranchIndexNumber = ($ConvertToNumber + 1);

git checkout -b $NextBranchIndexNumber;
git add .;
git commit -m "$NextBranchIndexNumber";