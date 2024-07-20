# file name: create-worker-files.ps1

$RawPathName = "          "
$PathName = $RawPathName.TrimStart().TrimEnd()

Push-Location $PathName;
Remove-Item *.worker.ps1;

$FileNames = Get-ChildItem -Path $PathName

foreach ($FileName in $FileNames) {
  $WorkerExtension = ".worker"

  if ($FileName -contains $WorkerExtension) {
    continue
  }

  $DirectoryName = (Get-Item $FileName).DirectoryName
  $Basename = (Get-Item $FileName).Basename
  $Extension = (Get-Item $FileName).Extension
  
  $NewName = $Basename + $WorkerExtension + $Extension
  $WorkerFile = Join-Path -Path $DirectoryName -ChildPath $NewName

  if (Test-Path $WorkerFile) {
    continue
  }

  Copy-Item $FileName -Destination $WorkerFile

}

Pop-Location