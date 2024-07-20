<#> fina = file name = directories-open-inclusive.ps1 #>

get-content "directories-open-inclusive.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:FEATURE_SELF_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:FEND_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:FEND_HOST_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:FEND_GUEST_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:BEND_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:CALLS_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath$env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:WEB_LINKS_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:TOOLS_ADDRESS
Start-Sleep -Seconds 2
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:MESSAGES_ADDRESS
Start-Sleep -Seconds 2