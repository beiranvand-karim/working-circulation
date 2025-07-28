<#> fina = file name = directories-multitude-commanding-order-recto-action-open.ps1 #>

get-content "directories-multitude-commanding-order-recto-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$ArgumentList =(
    "--application $env:APPLICATION" +
    " --command $env:COMMAND" +
    " --order $env:ORDER" +
    " --format $env:FORMAT" +
    " --filement $env:FILEMENT" +
    " --feature-name $env:FEATURE_NAME" +
    " --hosting-directory $env:HOSTING_DIRECTORY" +
    " --repository-directory $env:REPOSITORY_DIRECTORY" +
    " --primary-application-name $env:PRIMARY_APPLICATION_NAME" +
    " --secondary-application-name $env:SECONDARY_APPLICATION_NAME"
    )

Push-Location $env:CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY

start-process -FilePath $env:CAFDEM_EXECUTIVE_FILE_ADDRESS -ArgumentList $ArgumentList

Pop-Location