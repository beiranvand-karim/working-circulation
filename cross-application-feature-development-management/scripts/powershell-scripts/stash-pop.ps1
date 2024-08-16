<#> fina = file name = stash-pop.ps1 #>

get-content "stash-pop.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

push-location $env:LOCATION
git stash pop --index
pop-location