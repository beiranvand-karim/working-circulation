# file name: create.ps1
# https://angular.dev/cli/generate/component#Options

$name = "      ";

$name | ForEach-Object { $_ } {
    $RefinedName = $_.TrimStart().TrimEnd().Replace(" ", "-")
    ng generate c $RefinedName --skip-tests --standalone=false;
}