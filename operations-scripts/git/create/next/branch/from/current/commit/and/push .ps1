# file name: /create/from/current/branch.ps1

$CommandOutput = git log -1 --pretty=%B | Out-String;
$CurrentCommitName = [string]::join("", ($CommandOutput.Split("`n")));
$WindowsRemoveCarriageReturn = $CurrentCommitName.Replace("`r", "");
$ConvertToNumber = [int]$WindowsRemoveCarriageReturn;
$NextBranchCommitIndexNumber = ($ConvertToNumber + 1);

git checkout -b $NextBranchCommitIndexNumber;
git add .;
git commit -m "$NextBranchCommitIndexNumber";
git push --set-upstream origin $NextBranchCommitIndexNumber;
