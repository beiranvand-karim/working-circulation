# file name: create.ps1
# https://angular.dev/cli/generate/component#Options

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$name = $json.name;

$name | ForEach-Object { $_ } {
    $RefinedName = $_.TrimStart().TrimEnd().Replace(" ", "-")
    ng g module $RefinedName --routing;
    Set-Location ./$RefinedName;
    ng generate c $RefinedName --skip-tests --standalone=false;
}
