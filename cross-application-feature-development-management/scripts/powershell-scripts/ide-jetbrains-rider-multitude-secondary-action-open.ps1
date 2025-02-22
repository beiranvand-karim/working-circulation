<#> fina = file name = ide-jetbrains-rider-multitude-secondary-action-open.ps1 #>

get-content "ide-jetbrains-rider-multitude-secondary-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Push-Location $env:CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY

start-process -FilePath $env:CAFDEM_EXECUTIVE_FILE_ADDRESS -ArgumentList "--application $env:APPLICATION --command $env:COMMAND --ide-execute-file-location $env:RIDER_LOCATION  --application-location $env:SECONDARY_APPLICATION_LOCATION --ide-name $env:IDE_NAME --application-name $env:GUEST_APPLICATION_NAME --feature-name $env:FEATURE_NAME --hosting-directory $env:HOSTING_DIRECTORY"

Pop-Location