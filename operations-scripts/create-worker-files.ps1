# file name: create-worker-files.ps1

$ThisScript = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
$JsonFileContent = Join-Path -Path $ThisScript -ChildPath "input.worker.json";
$json = Get-Content -Path $JsonFileContent -Raw | ConvertFrom-Json;

$RawPathName = $json.RawPathName;
$PathName = $RawPathName.TrimStart().TrimEnd();

Push-Location $PathName;
Remove-Item *.worker.ps1;
Remove-Item *.worker.json;

$FileNames = Get-ChildItem -Path $PathName;

foreach ($FileName in $FileNames) {
  $WorkerExtension = ".worker";

  if ($FileName -contains $WorkerExtension) {
    continue;
  }

  $DirectoryName = (Get-Item $FileName).DirectoryName;
  $Basename = (Get-Item $FileName).Basename;
  $Extension = (Get-Item $FileName).Extension;
  
  $NewName = $Basename + $WorkerExtension + $Extension;
  $WorkerFile = Join-Path -Path $DirectoryName -ChildPath $NewName;

  if (Test-Path $WorkerFile) {
    continue;
  }

  Copy-Item $FileName -Destination $WorkerFile;

}

Pop-Location;