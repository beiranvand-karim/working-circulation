# file name: create-new-project.ps1

"" | ForEach-Object {$_} {
    ng new $_ --no-standalone;
}