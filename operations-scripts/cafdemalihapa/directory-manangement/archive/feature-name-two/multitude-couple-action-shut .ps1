$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$CafdemDirectory = $json.CafdemDirectory;
Push-Location $CafdemDirectory;

$feature_name = "feature-name-two"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"
$current_directory = $PWD.Path
$hosting_directory = "/home/karim/Documents/feature-development"

dotnet run `
    --application "directory-management" `
    --command "shut" `
    --filement "split" `
    --feature-name "$feature_name" `
    --executive-file-directory "$current_directory/Debug/net8.0/cafdemalihapa" `
    --scripts-directory "$current_directory/scripts" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name"

Pop-Location;