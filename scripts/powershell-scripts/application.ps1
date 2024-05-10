<#> fina = file name = application.ps1 #>

get-content "application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
set-location $env:COMPOSE_FILE_LOCATION
docker compose pull
docker compose up -d