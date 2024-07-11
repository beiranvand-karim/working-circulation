# file name: create-branch-with-commit.ps1

2 | ForEach-Object { $_ } {
    git checkout -b $_;
    git add .;
    git commit -m "$_";
    git push --set-upstream origin $_;
}
