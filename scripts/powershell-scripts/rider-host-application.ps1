<#> fina = file name = rider host application.ps1 #>

get-content "rider-host-application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:RIDER_LOCATION -ArgumentList $env:HOST_APPLICATION_LOCATION