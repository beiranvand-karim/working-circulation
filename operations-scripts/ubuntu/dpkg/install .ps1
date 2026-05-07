
$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$PackagePath = $json.PackagePath;
$RefinedPackagePath = $PackagePath.TrimStart().TrimEnd();

sudo dpkg -i $RefinedPackagePath