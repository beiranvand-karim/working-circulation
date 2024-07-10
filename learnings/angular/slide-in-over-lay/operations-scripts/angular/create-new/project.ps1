# file name: project.ps1

"" | ForEach-Object {$_} {
    ng new $_ --no-standalone --skip-tests;
}