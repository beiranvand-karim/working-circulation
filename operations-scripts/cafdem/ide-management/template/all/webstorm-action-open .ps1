$feature_name="wonderful feature"
$current_directory=$PWD.Path
$hosting_directory="$current_directory/workers/features"

dotnet run `
--application "ide-management" `
--command "open" `
--ide-execute-file-location  "" `
--application-location  "" `
--feature-name "$feature_name" `
--hosting-directory "$hosting_directory"