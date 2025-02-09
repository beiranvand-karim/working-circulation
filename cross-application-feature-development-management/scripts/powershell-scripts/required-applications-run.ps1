<#> fina = file name = required-applications-run.ps1 #>

get-content "required-applications-run.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_DESKTOP_LOCATION
start-process -FilePath $env:OUTLOOK_EMAIL_CLIENT_LOCATION -ArgumentList "/recycle"
start-process -FilePath $env:GITHUB_DESKTOP_LOCATION
start-process -FilePath $env:ZSCALER_CLIENT_CONNECTOR -ArgumentList "-shortcut"