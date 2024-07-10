# file name: pull-all-remote-branches.ps1

61..63 | ForEach-Object {$_} {
    git fetch -f origin ${_}:$_;
}
