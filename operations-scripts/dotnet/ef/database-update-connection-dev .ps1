
$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$WorkingDirectory = $json.WorkingDirectory;
$ConnectionStringDevelopment = $json.DefaultConnectionDevelopment;

Push-Location $WorkingDirectory

dotnet ef database update --connection $ConnectionStringDevelopment

Pop-Location
