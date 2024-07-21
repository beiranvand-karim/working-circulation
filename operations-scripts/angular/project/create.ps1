# file name: create.ps1
# https://angular.dev/cli/new#Options

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$name = $json.name;

$name | ForEach-Object { $_ } {
    $RefinedName = $_.TrimStart().TrimEnd().Replace(" ", "-")
    ng new $RefinedName --no-standalone --skip-tests --style=scss --ssr=false --routing --inline-style=false --inline-template=false;
} 