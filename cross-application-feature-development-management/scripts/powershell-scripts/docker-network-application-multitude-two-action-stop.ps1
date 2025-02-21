<#> fina = file name = docker-network-application-multitude-two-action-stop.ps1 #>

get-content "docker-network-application-multitude-two-action-stop.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
push-location $env:APPLICATION_COMPOSE_FILE_LOCATION
docker compose stop host-application-name guest-application-name
pop-location
