# file name: create.ps1
# https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$name = $json.name;
$RefinedName = $name.TrimStart().TrimEnd().Replace(" ", "-");

$RefinedName | ForEach-Object { $_ } {
    New-Item -Path "/Users/karimbeiranvand/Documents/GitHub/working-circulation/dotnet" -ItemType "directory" -Name "$_";
    Push-Location "/Users/karimbeiranvand/Documents/GitHub/working-circulation/dotnet/$_";
    dotnet new console --framework net8.0;
    Pop-Location;
}