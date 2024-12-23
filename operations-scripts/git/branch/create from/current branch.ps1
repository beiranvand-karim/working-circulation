# file name: /create/from/current/branch.ps1

$cmdOutput = git branch --show-current | Out-String
$CurrentBranchName = [string]::join("", ($cmdOutput.Split("`n")))
$CurrentBranchIndexNumber = [int] $CurrentBranchName;
$NextBranchIndexNumber = ($CurrentBranchIndexNumber + 1);

git checkout -b $NextBranchIndexNumber;
git add .;
git commit -m "$NextBranchIndexNumber";