<#> fina = file name = startup-add-to.ps1 #>

get-content "startup-add-to.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Copy-Item $env:ALL_INCLUSIVE_DIRECTOY_ADDRESS -Destination $env:STARTUP_DIRECTORY_LOCATION