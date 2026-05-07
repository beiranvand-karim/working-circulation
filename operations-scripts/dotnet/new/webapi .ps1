
$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$name = $json.Name_WebApi;
$ParentDirectoryPath = $json.ParentDirectoryPath_WebApi;
$RefinedName = $name.TrimStart().TrimEnd().Replace(" ", "-");


New-Item -Path "$ParentDirectoryPath" -ItemType "directory" -Name "$RefinedName";
Push-Location "$ParentDirectoryPath/$RefinedName";
dotnet new webapi --framework net8.0;
Pop-Location;