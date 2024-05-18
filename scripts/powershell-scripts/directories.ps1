<#> fina = file name = directories.ps1 #>

get-content "directories.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS "C:/feature naming/...../fend"
& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS "C:/feature naming/...../fend/fend...."
& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS "C:/feature naming/...../fend/fend...."
& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS "C:/feature naming/...../calls"
& $env:DIRECTORY_MANAGEMENT_EXECUTIVE_FILE_ADDRESS "C:/feature naming/...../bend"