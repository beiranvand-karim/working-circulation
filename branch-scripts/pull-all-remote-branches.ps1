
61..63 | ForEach-Object {$_} {
    git fetch -f origin ${_}:${_}
}
