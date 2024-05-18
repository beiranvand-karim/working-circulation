<#> fina = file name = application-stops.ps1 #>

get-content "application-stops.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
set-location $env:COMPOSE_FILE_LOCATION
dockee compose stop 