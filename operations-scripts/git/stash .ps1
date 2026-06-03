# file name: stash .ps1

$git_root = git rev-parse --show-toplevel
git -C $git_root stash --include-untracked
