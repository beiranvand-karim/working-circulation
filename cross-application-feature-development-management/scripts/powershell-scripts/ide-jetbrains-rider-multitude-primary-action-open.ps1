<#> fina = file name = ide-jetbrains-rider-multitude-primary-action-open.ps1 #>

get-content "ide-jetbrains-rider-multitude-primary-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$ArgumentList=@"
--application "ide-management" `
--command "close"
--ide-execute-file-location $env:RIDER_LOCATION `
--application-location $env:PRIMARY_APPLICATION_LOCATION `
--ide-name "rider" `
--application-name $env:HOST_APPLICATION_NAME
"@

Push-Location $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY

start-process -FilePath `
    $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList `
    $ArgumentList

Pop-Location