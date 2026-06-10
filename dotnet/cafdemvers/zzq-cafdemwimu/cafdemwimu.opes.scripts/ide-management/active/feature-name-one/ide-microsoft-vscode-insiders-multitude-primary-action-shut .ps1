$feature_name = "feature-name-one"
$hosting_directory = "C:\workplace\feature-development"
$repository_directory = "C:\workplace\GitHub\working-circulation"
$working_directory = "$repository_directory\dotnet\cafdemvers\zzq-cafdemwimu\cafdemwimu.console"

Push-Location $working_directory

dotnet run `
    --application "ide-management" `
    --command "close" `
    --ide-execute-file-location  "C:\Users\beira\AppData\Local\Programs\Microsoft VS Code Insiders\Code - Insiders.exe" `
    --application-location  "C:\workplace\GitHub\working-circulation\dotnet\Organumator\organumator\organumator.frontend" `
    --feature-name "$feature_name" `
    --hosting-directory "$hosting_directory" `
    --ide-name "vscode-insiders" `
    --application-name "ide-management"

Pop-Location