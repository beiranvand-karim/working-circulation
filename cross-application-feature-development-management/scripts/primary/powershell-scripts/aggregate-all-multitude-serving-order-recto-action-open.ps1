<#> fina = file name = aggregate-all-multitude-serving-order-recto-action-open.ps1 #>

get-content "aggregate-all-multitude-serving-order-recto-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

& "$(Split-Path $MyInvocation.MyCommand.Path)/aggregate-required-action-open.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/directories-multitude-serving-order-recto-action-open.env.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/infrastructure.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application-stops.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-rider-multitude-primary-action-open.ps1"

if ($env:IS_RIDER_GUEST_APPLICATION_RUNNING_PERMISSION_GRANTABLE -eq $true ) {
    Start-Sleep -Seconds 10
    & "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-rider-multitude-secondary-action-open.ps1"
}

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-webstorm-multitude-primary-action-open.ps1"

if ($env:IS_WEBSTORM_GUEST_CLIENTAPP_RUNNING_PERMISSION_GRANTABLE -eq $true ) {
    Start-Sleep -Seconds 10
    & "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-webstorm-multitude-secondary-action-open.ps1"
}

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/notepadplusplus-multitude-all-order-recto-action-open.ps1"

Start-Sleep -Seconds 10
Invoke-Expression 'cmd /c start powershell -Command {pwsh "run-primary-application.ps1";}'

Start-Sleep -Seconds 4
Invoke-Expression 'cmd /c start powershell -Command {pwsh "run-secondary-application.ps1";}'