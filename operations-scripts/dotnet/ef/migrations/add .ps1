
$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$MigrationMessage = $json.MigrationMessage;
$RefinedMigrationMessage = $MigrationMessage.TrimStart().TrimEnd().Replace(" ", "-");

$RefinedMigrationMessage | ForEach-Object { $_ } {
    dotnet ef migrations add $_
}