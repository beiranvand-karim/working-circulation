$feature_name = "feature-name-one"
$hosting_directory = "C:\workplace\feature-development"
$repository_directory = "C:\workplace\GitHub\working-circulation"
$working_directory = "$repository_directory\dotnet\cafdemalihapa"

Push-Location $working_directory

dotnet run `
    --application "ide-management" `
    --command "close" `
    --ide-execute-file-location  "C:\Users\beira\AppData\Local\Programs\Microsoft VS Code\Code.exe" `
    --application-location  "C:\workplace\GitHub\working-circulation\dotnet\Organumator\organumator\organumator.backend" `
    --feature-name "$feature_name" `
    --hosting-directory "$hosting_directory" `
    --ide-name "vscode" `
    --application-name "ide-management"

Pop-Location