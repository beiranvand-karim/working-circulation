$feature_name = "feature-name-one"
$hosting_directory = "C:\\workplace\\feature-development"
$feature_directory = "$hosting_directory\\$feature_name"

<#
.SYNOPSIS
    Configures the Windows Explorer view for the commands directory:
      - files sorted ascending by name
      - files grouped by name
      - view type set to List
#>

# Target the commands directory, built from the values above.
$TargetPath = "$feature_directory\automations\commands"

# Canonical property for the file name column.
$nameProperty = 'System.ItemNameDisplay'

# Explorer view modes (FOLDERVIEWMODE). List = 3.
$listViewMode = 3

# Normalize (collapses any doubled separators) and trim a trailing slash.
$TargetPath = [System.IO.Path]::GetFullPath($TargetPath).TrimEnd('\')

if (-not (Test-Path -LiteralPath $TargetPath -PathType Container)) {
    Write-Error "Directory not found: $TargetPath"
    return
}

$shell = New-Object -ComObject Shell.Application

# Open the folder so we get a live Explorer view to configure.
$shell.Open($TargetPath)

# Wait for the Explorer window to appear, then match it by path.
$window = $null
$deadline = (Get-Date).AddSeconds(10)
while (-not $window -and (Get-Date) -lt $deadline) {
    Start-Sleep -Milliseconds 300
    foreach ($candidate in $shell.Windows()) {
        if (-not $candidate.LocationURL) { continue }
        $location = ([System.Uri] $candidate.LocationURL).LocalPath.TrimEnd('\')
        if ($location -ieq $TargetPath) {
            $window = $candidate
            break
        }
    }
}

if (-not $window) {
    Write-Error "Could not find an Explorer window for: $TargetPath"
    return
}

$view = $window.Document

# View type: List.
$view.CurrentViewMode = $listViewMode

# Sort ascending by name ('+' = ascending).
$view.SortColumns = "prop:+$nameProperty"

# Group by name.
$view.GroupBy = $nameProperty

# Refresh so the new view settings take effect.
$window.Refresh()

Write-Host "Configured view for: $TargetPath (List, sorted and grouped by name, ascending)."
