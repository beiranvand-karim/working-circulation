<#> fina = file name = add-to-startup.ps1 #>

get-content "add-to-startup.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$ALL_INCLUSIVE_DIRECTOY_ADDRESS=$env.ALL_INCLUSIVE_DIRECTOY_ADDRESS
$STARTUP_DIRECTORY_LOCATION=$env.STARTUP_DIRECTORY_LOCATION
Copy-Item "$ALL_INCLUSIVE_DIRECTOY_ADDRESS/all-inclusive.bat" -Destination "$STARTUP_DIRECTORY_LOCATION"