<#> fina = file name = ide-microsoft-vscode-insiders-multitude-primary-action-shut.ps1 #>

get-content "ide-microsoft-vscode-insiders-multitude-primary-action-shut.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$ArgumentList =(
    "--application $env:APPLICATION" +
    " --command $env:COMMAND" +
    " --ide-execute-file-location $env:VSCODE_INSIDERS_LOCATION" +
    " --application-location $env:PRIMARY_CLIENTAPP_LOCATION" +
    " --ide-name $env:IDE_NAME" +
    " --application-name $env:PRIMARY_APPLICATION_NAME" +
    " --feature-name $env:FEATURE_NAME" +
    " --hosting-directory $env:HOSTING_DIRECTORY"
    )

Push-Location $env:CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY

start-process -FilePath $env:CAFDEM_EXECUTIVE_FILE_ADDRESS -ArgumentList $ArgumentList

Pop-Location