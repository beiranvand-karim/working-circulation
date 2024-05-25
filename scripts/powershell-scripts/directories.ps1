<#> fina = file name = directories.ps1 #>

get-content "directories.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS $env:FEND_ADDRESS
& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS $env:BEND_ADDRESS
& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS $env:CALLS_ADDRESS