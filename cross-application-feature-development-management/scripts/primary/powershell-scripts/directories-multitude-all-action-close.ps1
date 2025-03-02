<#> fina = file name = directories-multitude-all-action-close.ps1 #>

get-content "directories-multitude-all-action-close.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$fend_address = [uri]'FEND_ADDRESS';
$fend_host_address = [uri]'FEND_HOST_ADDRESS';
$fend_guest_address = [uri]'FEND_GUEST_ADDRESS';
$bend_address = [uri]'BEND_ADDRESS';
$calls_address = [uri]'CALLS_ADDRESS';
$tools_address = [uri]'TOOLS_ADDRESS';
$notes_messages_address = [uri]'NOTES_MESSAGES_ADDRESS';
$web_links_address = [uri]'WEB_LINKS_ADDRESS';

$directories_collection = @($fend_address, $fend_host_address, $fend_guest_address , $bend_address , $calls_address , $tools_address, $notes_messages_address , $web_links_address);

foreach ($d in $directories_collection) {
    Write-Host "folder: " $d.AbsoluteUri

    foreach ($w in (New-Object -ComObject Shell.Application).Windows()) {
        Write-Host "Application" $w.LocationURL

        if ($w.LocationURL -ieq $d.AbsoluteUri) {
            $w.Quit()
        }
    }
}

foreach ($d in $directories_collection) {
    Write-Host "folder: " $d.AbsoluteUri

    foreach ($w in (New-Object -ComObject Shell.Application).Windows()) {
        Write-Host "Application" $w.LocationURL

        if ($w.LocationURL -ieq $d.AbsoluteUri) {
            $w.Quit()
        }
    }
}