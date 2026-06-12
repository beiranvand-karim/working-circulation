    $feature_name = "feature-name-two"
$primary_application_name = "augustus"
$secondary_application_name = "decimus"
$tertiary_application_name = "meridius"
$hosting_directory = "C:\workplace\feature-development"
$repository_directory = "C:\workplace\GitHub\working-circulation"
$working_directory = "$repository_directory\dotnet\cafdemvers\zzq-cafdemwimu\cafdemwimu.console"
$scripts_directory = "$working_directory\scripts"

Push-Location $working_directory

dotnet run `
    --application "directory-management" `
    --command "shut" `
    --feature-name "$feature_name" `
    --executive-file-directory "$repository_directory\dotnet\cafdemvers\zzq-cafdemwimu\cafdemwimu.console\bin\Debug\net10.0\cafdemwimu.console.exe" `
    --scripts-directory "$scripts_directory" `
    --hosting-directory "$hosting_directory" `
    --primary-application-name "$primary_application_name" `
    --secondary-application-name "$secondary_application_name" `
    --tertiary-application-name "$tertiary_application_name"

Pop-Location;