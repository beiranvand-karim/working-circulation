<#> fina = file name = all-include-nothing-order-reverse.ps1 #>

get-content "all-include-nothing-order-reverse.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

& "$(Split-Path $MyInvocation.MyCommand.Path)/required-applications-run.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/directories-include-nothing-order-reverse-action-open.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/infrastructure.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application-stops.ps1"


Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/rider-guest-application.ps1"

if ($env:IS_RIDER_GUEST_APPLICATION_RUNNING_PERMISSION_GRANTABLE -eq $true ) {
    Start-Sleep -Seconds 10
    & "$(Split-Path $MyInvocation.MyCommand.Path)/rider-host-application.ps1"
}


Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/webstorm-guest-clientapp.ps1"

if ($env:IS_WEBSTORM_GUEST_CLIENTAPP_RUNNING_PERMISSION_GRANTABLE -eq $true ) {
    Start-Sleep -Seconds 10
    & "$(Split-Path $MyInvocation.MyCommand.Path)/webstorm-host-clientapp.ps1"
}


Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/notepadplusplus-multitude-all-order-reverse-action-open.ps1"

Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/run-multitude-all-order-reverse.ps1"