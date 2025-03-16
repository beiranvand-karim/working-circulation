<#> fina = file name = run-multitude-all-order-reverse.ps1 #>

& "$(Split-Path $MyInvocation.MyCommand.Path)/run-secondary-application.ps1"
Start-Sleep -Seconds 5
& "$(Split-Path $MyInvocation.MyCommand.Path)/dotnet-multitude-primary-order-recto-action-run.ps1"
