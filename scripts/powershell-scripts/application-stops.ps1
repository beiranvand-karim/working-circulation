<#> fina = file name = application-stops.ps1 #>

get-content "application-stops.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:DOCKER_CLI_LOCATION -ArgumentList "-SwitchWindowsEngine"
push-location $env:APPLICATION_COMPOSE_FILE_LOCATION
invoke-expression $env:DOCKER_COMPOSE_STOP_ALONG_WITH_ARGUMENTS
pop-location
