# file name: project.ps1
# https://angular.dev/cli/new#Options

$name = "      ";

$name | ForEach-Object { $_ } {
    $RefinedName = $_.TrimStart().TrimEnd().Replace(" ", "-")
    ng new $RefinedName --no-standalone --skip-tests --style=scss --ssr=false --routing --inline-style=false --inline-template=false;
} 