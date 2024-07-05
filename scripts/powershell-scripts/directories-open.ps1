<#> fina = file name = directories-open.ps1 #>

get-content "directories-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:FEND_ADDRESS
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:FEND_HOST_ADDRESS
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:FEND_GUEST_ADDRESS
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:BEND_ADDRESS
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:CALLS_ADDRESS
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:WEB_LINKS_ADDRESS
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList $env:TOOLS_ADDRESS