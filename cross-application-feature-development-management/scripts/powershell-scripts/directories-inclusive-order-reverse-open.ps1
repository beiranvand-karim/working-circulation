<#> fina = file name = directories-inclusive-order-reverse-open.ps1 #>

get-content "directories-inclusive-order-reverse-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Push-Location $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:FEATURE_SELF_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:FEND_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:FEND_GUEST_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:FEND_HOST_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:BEND_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:CALLS_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:TOOLS_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:NOTES_MESSAGES_ADDRESS"
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:WEB_LINKS_ADDRESS"
Start-Sleep -Seconds 2
Pop-Location