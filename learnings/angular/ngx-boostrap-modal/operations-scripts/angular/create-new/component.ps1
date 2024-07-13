# file name: component.ps1


$name = "      ";

$name | ForEach-Object { $_ } {
    $RefinedName = $_.TrimStart().TrimEnd().Replace(" ", "-")
    ng generate c $RefinedName --skip-tests;
}