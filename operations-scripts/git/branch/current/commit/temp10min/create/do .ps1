# file name: create.ps1

$command_output = git branch --show-current | Out-String
$current_branch_data = [string]::join("", ($command_output.Split("`n")))
$current_branch_data_carriage_return_removed = $current_branch_data.Replace("`r", "");
$temp10min = "$current_branch_data_carriage_return_removed-temp10min";
git checkout -b $temp10min;
git add .;
git commit -m "$temp10min";