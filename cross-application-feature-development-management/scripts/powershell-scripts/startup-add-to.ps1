<#> fina = file name = startup-add-to.ps1 #>

get-content "startup-add-to.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}
$startup_directory_location = [string]$env:STARTUP_DIRECTORY_LOCATION;
$destination = $startup_directory_location.Replace("`"", "");
$all_inclusive_directoy_address = [string]$env:ALL_INCLUSIVE_DIRECTOY_ADDRESS;
$object = $all_inclusive_directoy_address.Replace("`"", "");
Copy-Item $object -Destination $destination;