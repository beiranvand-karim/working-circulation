<#> fina = file name = stash.ps1 #>

get-content stash.env | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

set-location $env:LOCATION
git stash pop --index