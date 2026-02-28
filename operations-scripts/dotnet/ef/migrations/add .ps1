
$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$MigrationMessage = $json.MigrationMessage;
$RefinedMigrationMessage = $MigrationMessage.TrimStart().TrimEnd().Replace(" ", "-");
$WorkingDirectory = $json.WorkingDirectory;

Push-Location $WorkingDirectory

$RefinedMigrationMessage
dotnet ef migrations add $RefinedMigrationMessage

Pop-Location