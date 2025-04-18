<#> fina = file name = notepadplusplus-multitude-new-action-open.ps1 #>

get-content "notepadplusplus-multitude-new-action-open.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:NOTEPADDPP_EXECUTE_FILE_LOCATION -ArgumentList "-multiInst -nosession"