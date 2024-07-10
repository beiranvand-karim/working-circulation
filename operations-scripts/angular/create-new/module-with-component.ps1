# file name: module-with-component.ps1

"" | ForEach-Object {$_} {
    ng g module $_ --routing;
    $dir = $_.Replace(" ", "-")
    Set-Location ./$dir;
    ng generate c $_ --skip-tests;
}
