
$feature_name = "feature-name-one"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"

$repository_directory = "C:\workplace\GitHub\working-circulation"
$working_directory = "$repository_directory\dotnet\cafdemalihapa"
$hosting_directory = "C:\workplace\feature-development"
$feature_directory = "$hosting_directory\$feature_name"

Write-Host $feature_directory

Push-Location $working_directory

dotnet run `
    --application "cafdemalihapa" `
    --command "create-scripts" `
    --code-base "codebase" `
    --feature-name "$feature_name" `
    --executive-file-directory "$working_directory\Debug\net8.0\cafdemalihapa" `
    --repository-directory "$repository_directory" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name"

Pop-Location
