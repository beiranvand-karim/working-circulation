@echo off

cd [ ... fill in here ...]/working-circulation/cross-application-feature-development-management/bin/Debug/net8.0

cross-application-feature-development-management.exe ^
--templates-directory "environment-variables-template-files" ^
--destination-directory  "environment-variables-files" ^
--environment-variables-source-directory  "environment-variables-source"  ^
--feature-name "wonderful feature" ^
--executive-file-directory "/cross-application-feature-development-management/bin/Debug/net8.0/cross-application-feature-development-management" ^
--scripts-directory "[ ... fill in here ...]/working-circulation/scripts" ^
--repository-directory "[ ... fill in here ...]/working-circulation" ^
--hosting-directory "[ ... fill in here ...]" ^
--host-application-name "augustus" ^
--guest-application-name "julius"

pause