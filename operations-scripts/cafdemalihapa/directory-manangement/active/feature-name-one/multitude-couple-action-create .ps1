$feature_name = "feature-name-one"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"
$hosting_directory = "C:\workplace\feature-development"
$repository_directory = "C:\workplace\GitHub\working-circulation"
$working_directory = "$repository_directory\dotnet\cafdemalihapa"

Push-Location $working_directory

dotnet run `
    --application "directory-management" `
    --command "create" `
    --feature-name "$feature_name" `
    --executive-file-directory "$working_directory\\Debugnet8.0\\cafdemalihapa" `
    --scripts-directory "$working_directory\\scripts" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name"

Pop-Location;