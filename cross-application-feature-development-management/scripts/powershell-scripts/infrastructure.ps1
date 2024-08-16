<#> fina = file name = infrastructure.ps1 #>

get-content "infrastructure.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
push-location $env:INFRASTRUCTURE_COMPOSE_FILE_LOCATION
docker compose pull
docker compose up -d
pop-location