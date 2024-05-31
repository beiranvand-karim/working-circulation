@echo off

[ ... fill in here ...]/working-circulation/WorkingCirculation/EnvironmeentVariablesManagement/bin/Debug/net8.0/EnvironmeentVariablesManagement ^
--templates-directory "environment-variables-template-files" ^
--destination-directory  "environment-variables-files" ^
--environment-variables-source-directory  "environment-variables-source"  ^
--feature-name "wonderful feature" ^
--executive-file-directory "/EnvironmeentVariablesManagement/bin/Release/net8.0/EnvironmeentVariablesManagement" ^
--scripts-directory "" ^
--repository-directory "" ^
--hosting-directory "" ^
--host-application-name "augustus" ^
--guest-application-name "julius"

pause