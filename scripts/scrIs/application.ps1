<#> fina = file name = application.ps1 #>

get-content application.env | foreach {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

& $env:DOCKER_CLI_LOCATION -SwitchWindowsEngine
set-location $env:COMPOSE_FILE_LOCATION
docker compose pull
docker compose up -d
