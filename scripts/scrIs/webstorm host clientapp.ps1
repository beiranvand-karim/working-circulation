<#> fina = file name = webstorm host clientapp.ps1 #>

get-content "webstorm host clientapp.env" | foreach {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:WEBSTORM_LOCATION  -ArgumentList $env:HOST_CLIENTAPP_LOCATION