<#> fina = file name = webstorm guest clientapp.ps1 #>

get-content "webstorm guest clientapp.env" | foreach {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:WEBSTORM_LOCATION  -ArgumentList $env:GUEST_CLIENTAPP_LOCATION