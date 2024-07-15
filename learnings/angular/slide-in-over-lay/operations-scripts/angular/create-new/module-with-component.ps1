# file name: module-with-component.ps1
# https://angular.dev/cli/generate/component#Options

$name = "      ";

$name | ForEach-Object { $_ } {
    $RefinedName = $_.TrimStart().TrimEnd().Replace(" ", "-")
    ng g module $RefinedName --routing;
    Set-Location ./$RefinedName;
    ng generate c $RefinedName --skip-tests --standalone=false;
}
