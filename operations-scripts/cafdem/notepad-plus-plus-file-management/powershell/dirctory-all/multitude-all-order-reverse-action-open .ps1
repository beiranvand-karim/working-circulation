$feature_name="wonderful feature"
$primary_application_name="augustus"
$secondary_application_name="decimus"
$notepaddpp_execute_file_location=""
$repository_directory="/Users/karimbeiranvand/Documents/GitHub/working-circulation"
$working_directory="$repository_directory/cross-application-feature-development-management"
$hosting_directory="$working_directory/workers/features"
$feature_directory="$working_directory/workers/features/$feature_name"

Remove-Item -Recurse -Force -Path $feature_directory

Push-Location $working_directory

dotnet run `
--application "notepad-plus-plus-file-management" `
--command "open" `
--order "reverse" `
--feature-name "$feature_name" `
--notepaddpp-execute-file-location "$notepaddpp_execute_file_location" `
--hosting-directory "$hosting_directory" `
--primary-application-name "$primary_application_name" `
--secondary-application-name "$secondary_application_name"

Pop-Location
