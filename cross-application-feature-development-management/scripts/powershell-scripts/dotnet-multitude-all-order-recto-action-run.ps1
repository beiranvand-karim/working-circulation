<#> fina = file name = dotnet-multitude-all-order-recto-action-run.ps1 #>

& "$(Split-Path $MyInvocation.MyCommand.Path)/dotnet-multitude-primary-action-run.ps1"
Start-Sleep -Seconds 5
& "$(Split-Path $MyInvocation.MyCommand.Path)/dotnet-multitude-secondary-order-recto-action-run.ps1"
