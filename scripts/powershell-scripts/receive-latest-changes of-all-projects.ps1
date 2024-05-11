<#> fina = file name = receive latest changes of all projects.ps1 #>

get-content "receive-latest-changes-of-all-projects.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

start-process -FilePath $env:RECEIVER_LOCATION -ArgumentList "checkout develop" -Wait
start-process -FilePath $env:RECEIVER_LOCATION -ArgumentList "pull" -Wait

Write-Host -NoNewline  'press any key to coontinue ...'
$null = $Host.UI.RawUI.ReadKey('NoEcho, IncludedKeyDown')

