<#> fina = file name = run-tertiary-application.ps1 #>

get-content "run-tertiary-application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

if ($env:PRIMARY_APPLICATION_PROJECT_LOCATION -eq "") {
    Push-Location $env:TERTIARY_APPLICATION_PROJECT_LOCATION
    dotnet run --project $env:TERTIARY_APPLICATION_PROJECT_NAME
    Pop-Location
} else {
    Push-Location $env:PRIMARY_APPLICATION_PROJECT_LOCATION
    dotnet run
    Pop-Location
}
