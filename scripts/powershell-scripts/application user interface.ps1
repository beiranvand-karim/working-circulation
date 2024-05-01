<#> fina = file name = application user interface.ps1 #>

get-content infrastructure.env | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

set-location $env:APPLICATION_USER_INTERFACE_PROJECT_LOCATION
dotnet run