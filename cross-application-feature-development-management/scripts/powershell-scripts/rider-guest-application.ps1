<#> fina = file name = rider-guest-application.ps1 #>

get-content "rider-guest-application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:RIDER_LOCATION -ArgumentList $env:GUEST_APPLICATION_LOCATION