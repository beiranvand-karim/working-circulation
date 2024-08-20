# file name: create.ps1
# https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$name = $json.name;
$RefinedName = $name.TrimStart().TrimEnd().Replace(" ", "-");

$RefinedName | ForEach-Object { $_ } {
    New-Item -Path "/home/karim/Documents/GitHub/working-circulation/learnings/dotnet-core" -ItemType "directory" -Name "$_";
    Push-Location "/home/karim/Documents/GitHub/working-circulation/learnings/dotnet-core/$_";
    dotnet new console --framework net8.0;
    Pop-Location;
}