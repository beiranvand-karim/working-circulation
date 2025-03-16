<#> fina = file name = all-include-nothing-order-reverse.ps1 #>

get-content "all-include-nothing-order-reverse.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

& "$(Split-Path $MyInvocation.MyCommand.Path)/required-applications-run.ps1"
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

if ($env:IS_RIDER_GUEST_APPLICATION_RUNNING_PERMISSION_GRANTABLE -eq $true ) {
    Start-Sleep -Seconds 10
    & "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-rider-multitude-primary-action-open.ps1"
}


Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-webstorm-multitude-secondary-action-open.ps1"

if ($env:IS_WEBSTORM_GUEST_CLIENTAPP_RUNNING_PERMISSION_GRANTABLE -eq $true ) {
    Start-Sleep -Seconds 10
    & "$(Split-Path $MyInvocation.MyCommand.Path)/ide-jetbrains-webstorm-multitude-primary-action-open.ps1"
}


Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/notepadplusplus-multitude-all-order-reverse-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/dotnet-multitude-all-order-reverse-action-run.ps1"