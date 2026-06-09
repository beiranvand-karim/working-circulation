param(
    [switch]$UseFuncUI
)

$ProjectName = "cafdemwimu.opes.avalonia"

# Verify we're in the correct folder
if ((Split-Path -Leaf (Get-Location)) -ne $ProjectName) {
    Write-Error "Run this script from inside the '$ProjectName' folder."
    exit 1
}

# Install Avalonia templates if needed
dotnet new install Avalonia.Templates

# Create the project in the current directory
dotnet new avalonia.app -lang F# -n $ProjectName -o .

if ($UseFuncUI) {
    Write-Host "Adding FuncUI packages..."

    dotnet add package Avalonia.FuncUI
    dotnet add package Avalonia.FuncUI.Desktop

    Write-Host "FuncUI packages added."
}

Write-Host ""
Write-Host "Project created successfully."
Write-Host ""
Write-Host "Run with:"
Write-Host "dotnet run"