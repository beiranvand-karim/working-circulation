# file name: component.ps1

"" | ForEach-Object {$_} {
    ng generate c $_ --skip-tests;
}