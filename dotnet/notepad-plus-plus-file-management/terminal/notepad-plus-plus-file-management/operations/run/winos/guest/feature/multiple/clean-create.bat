rmdir /S /Q ""

dotnet run ^
--templates-directory "environment-variables-template-files" ^
--destination-directory  "environment-variables-files" ^
--environment-variables-source-directory  "environment-variables-source"  ^
--feature-name "wonderful feature" ^
--executive-file-directory "/cross-application-feature-development-management/bin/Debug/net8.0/cross-application-feature-development-management" ^
--scripts-directory "[ ... fill in here ...]/working-circulation/cross-application-feature-development-management/scripts" ^
--repository-directory "[ ... fill in here ...]/working-circulation" ^
--hosting-directory "[ ... fill in here ...]" ^
--host-application-name "[ ... fill in here ...]" ^
--guest-application-name "[ ... fill in here ...]"