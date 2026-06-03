# file name: create and return .ps1

$hasBigger = & "$PSScriptRoot\zzz-commit-numners-math\has-bigger-than-branch .ps1"
if ($hasBigger) {
    Write-Host "Aborted: there are commits on this branch with a number bigger than the branch number."
    exit 1
}

$current_branch = (git branch --show-current | Out-String).Split("`n") -join "" | ForEach-Object { $_.Replace("`r", "") }

$temp10min_branch = "$current_branch-temp10min"

& "$PSScriptRoot\branch\current\commit\temp10min\create\and\return .ps1"

$branch_exists = git branch --list $temp10min_branch
if (-not $branch_exists) {
    Write-Host "Branch '$temp10min_branch' was not created. Execution stopped."
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
    exit 1
}

$pending_changes = git status --porcelain
if ($pending_changes) {
    & "$PSScriptRoot\stash .ps1"
}

& "$PSScriptRoot\number-commits-drop .ps1"

& "$PSScriptRoot\bring-master-commits .ps1"

& "$PSScriptRoot\cherry-pick top .ps1"

& "$PSScriptRoot\rebase-to-master.ps1"


