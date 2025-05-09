<#> fina = file name = run-primary-application.ps1 #>

get-content "run-primary-application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

Push-Location $env:HOST_APPLICATION_PROJECT_LOCATION
dotnet run
Pop-Location