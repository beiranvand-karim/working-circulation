<#> fina = file name = docker-network-secondary-multitude-two-action-stop.ps1 #>

get-content "docker-network-secondary-multitude-two-action-stop.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
push-location $env:APPLICATION_COMPOSE_FILE_LOCATION
docker compose stop primary-application-name secondary-application-name
pop-location
