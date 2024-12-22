# file name: create-temp10min.ps1

$cmdOutput = git branch --show-current | Out-String
$CurrentBranchName = [string]::join("", ($cmdOutput.Split("`n")))
$CurrentBranchIndexNumber = [int] $CurrentBranchName;
$NextBranchIndexNumber = ($CurrentBranchIndexNumber + 1);

git checkout -b $NextBranchIndexNumber;
git add .;
git commit -m "$NextBranchIndexNumber";
git push --set-upstream origin $NextBranchIndexNumber;