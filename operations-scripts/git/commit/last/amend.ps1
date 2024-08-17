# file name: amend.ps1

$cmdOutput = git branch --show-current | Out-String
$CurrentBranchName = [string]::join("", ($cmdOutput.Split("`n")))
$CurrentBranchIndexNumber = [int] $CurrentBranchName;

$CurrentBranchIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~$_;
    git add .
    git commit -m "$RefinedBranchIndexNumber";
}