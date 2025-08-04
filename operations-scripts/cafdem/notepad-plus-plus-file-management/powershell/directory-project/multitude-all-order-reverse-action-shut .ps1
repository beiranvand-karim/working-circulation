$feature_name="wonderful feature"
$primary_application_name="augustus"
$secondary_application_name="decimus"
$current_directory=$PWD.Path
$hosting_directory="$current_directory/workers/features"
$notepaddpp_execute_file_location=""

dotnet run `
--application "notepad-plus-plus-file-management" `
--command "close" `
--order "reverse" `
--feature-name "$feature_name" `
--notepaddpp-execute-file-location "$notepaddpp_execute_file_location" `
--hosting-directory "$hosting_directory" `
--primary-application-name "$primary_application_name" `
--secondary-application-name "$secondary_application_name"
