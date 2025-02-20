<#> fina = file name = ide-jetbrains-rider-multitude-host-action-open.ps1 #>

get-content "ide-jetbrains-rider-multitude-host-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:RIDER_LOCATION -ArgumentList $env:GUEST_APPLICATION_LOCATION