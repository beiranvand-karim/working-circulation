$feature_name = "feature-name-one"
$hosting_directory = "C:\\workplace\\feature-development"
$repository_directory = "C:\\workplace\\GitHub\\working-circulation"
$working_directory = "$repository_directory\\dotnet\\cafdemalihapa"

Push-Location $working_directory

dotnet run `
    --application "ide-management" `
    --command "open" `
    --ide-execute-file-location  "C:\\Program Files\\JetBrains\\WebStorm 2026.1.2\\bin\\webstorm64.exe" `
    --application-location  "C:\\workplace\\GitHub\\working-circulation\\dotnet\\Organumator\\organumator\\organumator.frontend" `
    --feature-name "$feature_name" `
    --hosting-directory "$hosting_directory" `
    --ide-name "webstorm" `
    --application-name "ide-management"

Pop-Location