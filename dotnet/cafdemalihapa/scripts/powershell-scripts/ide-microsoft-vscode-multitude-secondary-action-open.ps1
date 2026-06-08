<#> fina = file name = ide-microsoft-vscode-multitude-secondary-action-open.ps1 #>

get-content "ide-microsoft-vscode-multitude-secondary-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$ArgumentList =(
    "--application $env:APPLICATION" +
    " --command $env:COMMAND" +
    " --ide-execute-file-location $env:VSCODE_LOCATION" +
    " --application-location $env:SECONDARY_APPLICATION_LOCATION" +
    " --ide-name $env:IDE_NAME" +
    " --application-name $env:SECONDARY_APPLICATION_NAME" +
    " --feature-name $env:FEATURE_NAME" +
    " --hosting-directory $env:HOSTING_DIRECTORY"
    )

Push-Location $env:CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY

if ($IsLinux) {
    start-process -FilePath $env:CAFDEM_EXECUTIVE_FILE_ADDRESS -ArgumentList $ArgumentList
    [Console]::ReadKey($true)
}
else {
    start-process -FilePath $env:CAFDEM_EXECUTIVE_FILE_ADDRESS -ArgumentList $ArgumentList
}
Pop-Location