
$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$WorkingDirectory = $json.WorkingDirectory;

Push-Location $WorkingDirectory

dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.23

Pop-Location
