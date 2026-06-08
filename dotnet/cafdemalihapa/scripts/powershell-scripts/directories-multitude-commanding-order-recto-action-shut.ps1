<#> fina = file name = directories-multitude-commanding-order-recto-action-shut.ps1 #>

get-content "directories-multitude-commanding-order-recto-action-shut.env" | ForEach-Object {
    $name, $value = $_.split("=")
    set-content env:\$name $value
}

$feature_self_address = [uri]'FEATURE_SELF_ADDRESS';
$operations_directory_path = [uri]'OPERATIONS_DIRECTORY_PATH';
$fend_address = [uri]'FEND_ADDRESS';
$fend_host_address = [uri]'FEND_HOST_ADDRESS';
$fend_guest_address = [uri]'FEND_GUEST_ADDRESS';
$bend_address = [uri]'BEND_ADDRESS';
$bend_host_address = [uri]'BEND_HOST_ADDRESS';
$bend_guest_address = [uri]'BEND_GUEST_ADDRESS';
$calls_address = [uri]'CALLS_ADDRESS';
$tools_address = [uri]'TOOLS_ADDRESS';
$notes_messages_address = [uri]'NOTES_MESSAGES_ADDRESS';
$web_links_address = [uri]'WEB_LINKS_ADDRESS';
$data_address = [uri]'DATA_ADDRESS';
$environment_variables_files_address = [uri]'ENVIRONMENT_VARIABLES_FILES_ADDRESS';
$automations_address = [uri]'AUTOMATIONS_ADDRESS';
$processes_meta_data_address = [uri]'PROCESSES_META_DATA_ADDRESS';

$directories_collection = @(
    $feature_self_address,
    $operations_directory_path,
    $fend_address,
    $fend_host_address,
    $fend_guest_address,
    $bend_address,
    $bend_host_address,
    $bend_guest_address,
    $calls_address,
    $tools_address,
    $notes_messages_address,
    $web_links_address,
    $data_address,
    $environment_variables_files_address,
    $automations_address,
    $processes_meta_data_address
);

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