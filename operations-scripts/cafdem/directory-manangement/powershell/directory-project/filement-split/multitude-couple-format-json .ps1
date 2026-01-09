$feature_name="wonderful feature"
$primary_application_name="augustus"
$secondary_application_name="decimus"
$current_directory=$PWD.Path
$hosting_directory="$current_directory/workers/features"
$repository_directory=(get-item $current_directory).parent.FullName 

dotnet run `
--application "directory-management" `
--command "create-scripts" `
--format "json" `
--filement "split" `
--feature-name "$feature_name" `
--executive-file-directory "$current_directory/bin/Debug/net8.0/cross-application-feature-development-management" `
--repository-directory "$repository_directory" `
--hosting-directory "$hosting_directory" `
--primary-application-name "$primary_application_name" `
--secondary-application-name "$secondary_application_name"
