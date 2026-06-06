$feature_name = "feature-name-one"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"
$notepaddpp_execute_file_location = "C:\\Program Files\\Notepad++\\notepad++.exe"
$repository_directory = "C:\\workplace\\GitHub\\working-circulation"
$working_directory = "$repository_directory\\dotnet\\cafdemalihapa"
$hosting_directory = "C:\\workplace\\feature-development"

# $feature_directory = "$hosting_directory\\$feature_name"
# Remove-Item -Recurse -Force -Path $feature_directory

Push-Location $working_directory

dotnet run `
    --application "notepad-plus-plus-file-management" `
    --command "open" `
    --order "recto" `
    --feature-name "$feature_name" `
    --notepaddpp-execute-file-location "$notepaddpp_execute_file_location" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name"

Pop-Location
