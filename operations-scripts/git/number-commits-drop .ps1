$branch = git rev-parse --abbrev-ref HEAD
$commits = git log $branch --oneline
$numberOnly = $commits | Where-Object { $_ -match '^\S+ \d+$' }

Write-Host "Commits with only a number as title: $($numberOnly.Count)"

$hashes = $numberOnly | ForEach-Object { ($_ -split ' ')[0] }
$oldestHash = $hashes[-1]

# Write a temp editor script that marks numbered commits as drop
$editorScript = Join-Path $PSScriptRoot "_rebase_editor.ps1"
$hashArray = ($hashes | ForEach-Object { "`"$_`"" }) -join ','
@"
param(`$rebaseFile)
`$drops = @($hashArray)
`$lines = Get-Content `$rebaseFile
`$lines = `$lines | ForEach-Object {
    `$line = `$_
    foreach (`$h in `$drops) {
        if (`$line -match "^pick `$h") {
            `$line = `$line -replace '^pick', 'drop'
            break
        }
    }
    `$line
}
`$lines | Set-Content `$rebaseFile
"@ | Set-Content $editorScript

$env:GIT_SEQUENCE_EDITOR = "pwsh -File `"$editorScript`""
git rebase -i "${oldestHash}^"
Remove-Item Env:\GIT_SEQUENCE_EDITOR
Remove-Item $editorScript