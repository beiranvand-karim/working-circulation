<#> fina = file name = directories-multitude-serving-order-recto-action-open.ps1 #>

get-content "directories-multitude-serving-order-recto-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Push-Location $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY


if ($env:IS_OPENING_FEND_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:FEND_ADDRESS"
    Start-Sleep -Millisecond 700
}

if ($env:IS_OPENING_FEND_HOST_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:FEND_HOST_ADDRESS"
    Start-Sleep -Millisecond 700
}

if ($env:IS_OPENING_FEND_GUEST_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:FEND_GUEST_ADDRESS"
    Start-Sleep -Millisecond 700
}

if ($env:IS_OPENING_BEND_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:BEND_ADDRESS"
    Start-Sleep -Millisecond 700
}

if ($env:IS_OPENING_CALLS_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:CALLS_ADDRESS"
    Start-Sleep -Millisecond 700
}

if ($env:IS_OPENING_TOOLS_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:TOOLS_ADDRESS"
    Start-Sleep -Millisecond 700
}

if ($env:IS_OPENING_NOTES_MESSAGES_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:NOTES_MESSAGES_ADDRESS"
    Start-Sleep -Millisecond 700
}

if ($env:IS_OPENING_WEB_LINKS_ADDRESS -eq $true ) {
    start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:WEB_LINKS_ADDRESS"
    Start-Sleep -Millisecond 700
}
Pop-Location