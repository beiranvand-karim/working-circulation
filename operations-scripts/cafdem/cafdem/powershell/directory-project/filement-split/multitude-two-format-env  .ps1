$feature_name="wonderful feature"
$primary_application_name="augustus"
$secondary_application_name="decimus"
$current_directory=$PWD.Path
$hosting_directory="$current_directory/workers/features"

rm -rf "$current_directory/workers/features/$feature_name"

dotnet run `
--application "cross-application-feature-development-management" `
--command "create-scripts" `
--filement "split" `
--feature-name "$feature_name" `
--executive-file-directory "$current_directory/bin/Debug/net8.0/cross-application-feature-development-management" `
--scripts-directory "$current_directory/scripts" `
--hosting-directory "$hosting_directory" `
--primary-application-name "$primary_application_name" `
--secondary-application-name "$secondary_application_name"
