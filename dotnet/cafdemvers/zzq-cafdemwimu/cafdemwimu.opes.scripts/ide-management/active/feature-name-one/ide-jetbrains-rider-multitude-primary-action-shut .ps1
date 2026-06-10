$feature_name = "feature-name-one"
$hosting_directory = "C:\workplace\feature-development"
$repository_directory = "C:\workplace\GitHub\working-circulation"
$working_directory = "$repository_directory\dotnet\cafdemvers\zzq-cafdemwimu\cafdemwimu.console"

Push-Location $working_directory

dotnet run `
    --application "ide-management" `
    --command "close" `
    --ide-execute-file-location  "C:\Program Files\JetBrains\JetBrains Rider 2026.1.2\bin\rider64.exe" `
    --application-location  "C:\workplace\GitHub\working-circulation\dotnet\Organumator\organumator\organumator.backend\organumator.sln" `
    --feature-name "$feature_name" `
    --hosting-directory "$hosting_directory" `
    --ide-name "rider" `
    --application-name "ide-management"

Pop-Location