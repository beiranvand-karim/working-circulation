<#> fina = file name = dotnet-multitude-all-order-recto-action-run.ps1 #>

& "$(Split-Path $MyInvocation.MyCommand.Path)/run-primary-application.ps1"
Start-Sleep -Seconds 5
& "$(Split-Path $MyInvocation.MyCommand.Path)/run-secondary-application.ps1"
