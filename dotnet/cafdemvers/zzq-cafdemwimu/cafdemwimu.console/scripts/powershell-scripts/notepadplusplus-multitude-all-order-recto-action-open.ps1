<#> fina = file name = notepadplusplus-multitude-all-order-recto-action-open.ps1 #>

get-content "notepadplusplus-multitude-all-order-recto-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$ArgumentList =(
    "--application $env:APPLICATION" +
    " --command $env:COMMAND" +
    " --notepaddpp-execute-file-location $env:NOTEPADDPP_EXECUTE_FILE_LOCATION" +
    " --feature-name $env:FEATURE_NAME" +
    " --hosting-directory $env:HOSTING_DIRECTORY" +
    " --primary-application-name $env:PRIMARY_APPLICATION_NAME" +
    " --secondary-application-name $env:SECONDARY_APPLICATION_NAME"
    )

Push-Location $env:CAFDEM_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY

start-process -FilePath $env:CAFDEM_EXECUTIVE_FILE_ADDRESS -ArgumentList $ArgumentList

Pop-Location