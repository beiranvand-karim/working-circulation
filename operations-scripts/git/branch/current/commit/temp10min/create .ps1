# file name: create.ps1

$cmdOutput = git branch --show-current | Out-String
$my_string = [string]::join("", ($cmdOutput.Split("`n")))
$temp10min = "$my_string-temp10min";
git checkout -b $temp10min;
git add .;
git commit -m "$temp10min";