<#> fina = file name = all.ps1 #>

& "$(Split-Path $MyInvocation.MyCommand.Path)/required-applications-run.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/receive-latest-changes-of-all-projects.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/directories-open.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/infrastructure.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application-stops.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/rider-host-application.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/rider-guest-application.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/webstorm-host-clientapp.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/webstorm-guest-clientapp.ps1"
Start-Sleep -Seconds 10
& "$(Split-Path $MyInvocation.MyCommand.Path)/application-user-interface.ps1"