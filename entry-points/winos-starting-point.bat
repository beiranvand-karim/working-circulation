@echo off

[ ... fill in here ...]/working-circulation/WorkingCirculation/EnvironmeentVariablesManagement/bin/Debug/net8.0/EnvironmeentVariablesManagement.exe ^
--templates-directory "environment-variables-template-files" ^
--destination-directory  "environment-variables-files" ^
--environment-variables-source-directory  "environment-variables-source"  ^
--feature-name "wonderful feature" ^
--executive-file-directory "/EnvironmeentVariablesManagement/bin/Debug/net8.0/EnvironmeentVariablesManagement" ^
--scripts-directory "[ ... fill in here ...]/working-circulation/scripts" ^
--repository-directory "[ ... fill in here ...]/working-circulation" ^
--hosting-directory "[ ... fill in here ...]" ^
--host-application-name "augustus" ^
--guest-application-name "julius"

pause