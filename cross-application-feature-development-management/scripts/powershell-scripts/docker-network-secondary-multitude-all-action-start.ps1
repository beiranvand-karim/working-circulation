<#> fina = file name = docker-network-secondary-multitude-all-action-start.ps1 #>

get-content "docker-network-secondary-multitude-all-action-start.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
push-location $env:APPLICATION_COMPOSE_FILE_LOCATION
az acr login --name $env:DOCKER_LOGIN_NAME
$AZURE_CLIENT_SECRET = AZURE_CLIENT_SECRET_FROM_ENVIRONMENT_VARIABLES
$env:AZURE_CLIENT_SECRET = $AZURE_CLIENT_SECRET
docker compose down
docker compose pull
docker compose up -d

pop-location