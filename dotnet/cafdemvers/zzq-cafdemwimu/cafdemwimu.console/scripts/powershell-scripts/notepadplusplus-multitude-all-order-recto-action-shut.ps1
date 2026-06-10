<#> fina = file name = notepadplusplus-multitude-all-order-recto-action-shut.ps1 #>

get-content "notepadplusplus-multitude-all-order-recto-action-shut.env" | ForEach-Object {
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

Push-Location $env:NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_CONTAINING_DIRECTORY

start-process -FilePath $env:NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_LOCATION -ArgumentList $ArgumentList

Pop-Location