# file name: module-with-component.ps1


$name = "      ";

$name | ForEach-Object { $_ } {
    $RefinedName = $_.TrimStart().TrimEnd().Replace(" ", "-")
    ng g module $RefinedName --routing;
    Set-Location ./$RefinedName;
    ng generate c $RefinedName --skip-tests;
}
