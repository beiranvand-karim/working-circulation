# file name: /git/commit/last/amend/do.bat

$CommandOutput = git branch --show-current | Out-String
$CurrentBranchName = [string]::join("", ($CommandOutput.Split("`n")))
$CurrentBranchIndexNumber = [int] $CurrentBranchName;

$CurrentBranchIndexNumber | ForEach-Object { $_ } {
    git reset --soft HEAD~1;
    git add .
    git commit -m "$_";
    git push -f;
}