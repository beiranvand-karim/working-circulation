<#> fina = file name = add-to-startup.ps1 #>

get-content "add-to-startup.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Copy-Item $env:ALL_INCLUSIVE_DIRECTOY_ADDRESS -Destination $env:STARTUP_DIRECTORY_LOCATION