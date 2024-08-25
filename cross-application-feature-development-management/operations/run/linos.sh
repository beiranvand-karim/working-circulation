#!/bin/bash

hosting_directory=${PWD}
github_desktop_directory=
host_application_name=
guest_application_name=

dotnet run \
--templates-directory "environment-variables-template-files" \
--destination-directory  "environment-variables-files" \
--environment-variables-source-directory  "environment-variables-source"  \
--feature-name "wonderful feature-v3" \
--executive-file-directory "/cross-application-feature-development-management/bin/Debug/net8.0/cross-application-feature-development-management"  \
--scripts-directory "${github_desktop_directory}/working-circulation/cross-application-feature-development-management/scripts" \
--repository-directory "${github_desktop_directory}/working-circulation" \
--hosting-directory "${hosting_directory}/workers" \
--host-application-name "${host_application_name}" \
--guest-application-name "${guest_application_name}"