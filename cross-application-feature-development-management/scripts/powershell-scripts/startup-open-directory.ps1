<#> fina = file name = startup-open-directory.ps1 #>

get-content "startup-open-directory.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Push-Location $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS_CONTAINING_DIRECTORY
start-process -FilePath $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS -ArgumentList "--directory-to-be-open $env:STARTUP_DIRECTORY_LOCATION"
Pop-Location