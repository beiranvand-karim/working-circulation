<#> fina = file name = docker-network-primary-multitude-all-action-start.ps1 #>

get-content "docker-network-primary-multitude-all-action-start.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
push-location $env:INFRASTRUCTURE_COMPOSE_FILE_LOCATION
az acr login --name $env:DOCKER_LOGIN_NAME
docker compose down
docker compose pull
docker compose up -d
pop-location