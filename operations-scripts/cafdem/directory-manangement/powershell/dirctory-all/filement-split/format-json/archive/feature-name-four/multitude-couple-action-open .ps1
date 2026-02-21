$feature_name = "feature-name-four"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"
$current_directory = $PWD.Path
$hosting_directory = "/home/karim/Documents/feature-development"

dotnet run `
    --application "directory-management" `
    --format "json" `
    --command "open" `
    --filement "split" `
    --code-base "codebase" `
    --feature-name "$feature_name" `
    --executive-file-directory "$current_directory/bin/Debug/net8.0/cross-application-feature-development-management" `
    --scripts-directory "$current_directory/scripts" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name"
