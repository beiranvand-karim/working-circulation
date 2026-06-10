<#> fina = file name = run-secondary-application.ps1 #>

get-content "run-secondary-application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

if ($env:PRIMARY_APPLICATION_PROJECT_LOCATION -eq "") {
    Push-Location $env:SECONDARY_APPLICATION_PROJECT_LOCATION
    dotnet run --project $env:SECONDARY_APPLICATION_PROJECT_NAME
    Pop-Location
} else {
    Push-Location $env:PRIMARY_APPLICATION_PROJECT_LOCATION
    dotnet run
    Pop-Location
}
