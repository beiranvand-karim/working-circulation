<#> fina = file name = ide-jetbrains-webstrom-multitude-secondary-action-open.ps1 #>

get-content "ide-jetbrains-webstrom-multitude-secondary-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:WEBSTORM_LOCATION -ArgumentList $env:SECONDARY_CLIENTAPP_LOCATION