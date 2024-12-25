#!/bin/bash

hosting_directory=${PWD}

dotnet run \
--templates-directory "environment-variables-template-files" \
--destination-directory  "environment-variables-files" \
--environment-variables-source-directory  "environment-variables-source"  \
--feature-name "wonderful feature-v3" \
--executive-file-directory "/cross-application-feature-development-management/bin/Debug/net8.0/cross-application-feature-development-management"  \
--scripts-directory "[ ... fill in here ...]/working-circulation/cross-application-feature-development-management/scripts" \
--repository-directory "[ ... fill in here ...]/working-circulation" \
--hosting-directory "${hosting_directory}" \
--host-application-name "[ ... fill in here ...]" \
--guest-application-name "[ ... fill in here ...]"