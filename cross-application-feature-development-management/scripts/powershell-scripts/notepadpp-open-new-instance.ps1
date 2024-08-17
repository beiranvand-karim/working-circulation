<#> fina = file name = notepadpp-open-new-instance.ps1 #>

get-content "notepadpp-open-new-instance.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:NOTEPADDPP_EXECUTE_FILE_LOCATION -ArgumentList "-multiInst"