
$feature_name = "feature-name-one"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"

$repository_directory = "/home/karim/Documents/GitHub/working-circulation"
$working_directory = "$repository_directory/cross-application-feature-development-management"
$hosting_directory = "/home/karim/Documents/feature-development"
$feature_directory = "/home/karim/Documents/feature-development/$feature_name"

Write-Host $feature_directory

Remove-Item -Recurse -Force -Path $feature_directory

Push-Location $working_directory

dotnet run `
    --application "cross-application-feature-development-management" `
    --command "create-scripts" `
    --format "json" `
    --filement "split" `
    --code-base "codebase" `
    --feature-name "$feature_name" `
    --executive-file-directory "$working_directory/bin/Debug/net8.0/cross-application-feature-development-management" `
    --repository-directory "$repository_directory" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name"

Pop-Location
