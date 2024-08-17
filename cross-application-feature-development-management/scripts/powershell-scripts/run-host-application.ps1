<#> fina = file name = run-host-application.ps1 #>

get-content "run-host-application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

set-location $env:HOST_APPLICATION_PROJECT_LOCATION
dotnet run