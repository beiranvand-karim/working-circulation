<#> fina = file name = notepadpp-all-close.ps1 #>

get-content "notepadpp-all-close.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}
Push-Location $env:NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_CONTAINING_DIRECTORY
$ArgumentList = "--command $env:COMMAND --notepaddpp-execute-file-location $env:NOTEPADDPP_EXECUTE_FILE_LOCATION --feature-name $env:FEATURE_NAME  --hosting-directory $env:HOSTING_DIRECTORY --host-application-name $env:HOST_APPLICATION_NAME --guest-application-name $env:GUEST_APPLICATION_NAME"
start-process -FilePath $env:NOTEPAD_PLUS_PLUS_FILE_MANAGEMENT_EXECUTIVE_FILE_LOCATION -ArgumentList $ArgumentList
Pop-Location