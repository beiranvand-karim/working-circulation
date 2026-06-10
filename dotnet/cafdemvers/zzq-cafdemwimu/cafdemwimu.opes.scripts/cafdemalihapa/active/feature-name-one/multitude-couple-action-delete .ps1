
$feature_name = "feature-name-one"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"

$repository_directory = "C:\workplace\GitHub\working-circulation"
$working_directory = "$repository_directory\dotnet\cafdemvers\zzq-cafdemwimu\cafdemwimu.console"
$hosting_directory = "C:\workplace\feature-development"
$feature_directory = "$hosting_directory\$feature_name"

Write-Host $feature_directory

Remove-Item -Recurse -Force -Path $feature_directory

Push-Location $working_directory

dotnet run `
    --application "cafdemalihapa" `
    --command "create-scripts" `
    --code-base "codebase" `
    --feature-name "$feature_name" `
    --executive-file-directory "$repository_directory\dotnet\cafdemvers\zzq-cafdemwimu\cafdemwimu.console\bin\Debug\net10.0\cafdemwimu.console.exe" `
    --repository-directory "$repository_directory" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name"

Pop-Location
