$feature_name="wonderful feature"
$host_application_name="augustus"
$guest_application_name="decimus"
$current_directory=$PWD.Path
$hosting_directory="$current_directory/workers/features"
$repository_directory=(get-item $current_directory).parent.FullName 

Remove-Item -Recurse -Force -Path "$current_directory/workers/features/$feature_name"

dotnet run `
--application "cross-application-feature-development-management" `
--command "create-scripts" `
--format "json" `
--filement "split" `
--feature-name "$feature_name" `
--executive-file-directory "$current_directory/bin/Debug/net8.0/cross-application-feature-development-management" `
--repository-directory "$repository_directory" `
--hosting-directory "$hosting_directory" `
--host-application-name "$host_application_name" `
--guest-application-name "$guest_application_name"
