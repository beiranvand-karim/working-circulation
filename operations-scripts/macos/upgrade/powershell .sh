# https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-macos?view=powershell-7.5

brew install powershell/tap/powershell
rm '/usr/local/bin/pwsh'
brew link powershell