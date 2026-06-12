<#> fina = file name = aggregate-all-multitude-serving-order-reverse-action-open.ps1 #>

get-content "aggregate-all-multitude-serving-order-reverse-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

& "$(Split-Path $MyInvocation.MyCommand.Path)/aggregate-required-action-open.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/directories-multitude-serving-order-reverse-action-open.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/infrastructure.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application-stops.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-rider-multitude-secondary-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-rider-multitude-primary-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-webstorm-multitude-secondary-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-rider-multitude-tertiary-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-webstorm-multitude-primary-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-webstorm-multitude-tertiary-action-open.ps1"

& "$(Split-Path $MyInvocation.MyCommand.Path)/notepadplusplus-multitude-all-order-reverse-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/dotnet-multitude-all-order-reverse-action-run.ps1"
