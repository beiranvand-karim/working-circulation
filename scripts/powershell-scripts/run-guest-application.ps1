<#> fina = file name = run-guest-application.ps1 #>

get-content "run-guest-application.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

set-location $env:GUEST_APPLICATION_PROJECT_LOCATION
dotnet run --project $env:GUEST_APPLICATION_PROJECT_NAME