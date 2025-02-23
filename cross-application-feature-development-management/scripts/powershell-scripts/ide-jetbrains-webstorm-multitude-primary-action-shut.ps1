<#> fina = file name = ide-jetbrains-webstorm-multitude-primary-action-shut.ps1 #>

get-content "ide-jetbrains-webstorm-multitude-primary-action-shut.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Push-Location $env:CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY

start-process -FilePath $env:CAFDEM_EXECUTIVE_FILE_ADDRESS -ArgumentList "--application $env:APPLICATION --command $env:COMMAND --ide-execute-file-location $env:WEBSTORM_LOCATION  --application-location $env:PRIMARY_CLIENTAPP_LOCATION --ide-name $env:IDE_NAME --application-name $env:PRIMARY_APPLICATION_NAME --feature-name $env:FEATURE_NAME --hosting-directory $env:HOSTING_DIRECTORY"

Pop-Location