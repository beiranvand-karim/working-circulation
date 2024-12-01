# file name: /create/from/current/branch.ps1

$cmdOutput = git branch --show-current | Out-String
$CurrentBranchName = [string]::join("", ($cmdOutput.Split("`n")))
$CurrentBranchIndexNumber = [int] $CurrentBranchName;
$NextBranchCommitIndexNumber = ($CurrentBranchIndexNumber + 1);

git checkout -b $NextBranchCommitIndexNumber;
git add .;
git commit -m "$NextBranchCommitIndexNumber";