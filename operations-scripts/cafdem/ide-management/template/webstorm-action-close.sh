#!/bin/bash

feature_name="wonderful feature"
host_application_name="augustus"
guest_application_name="decimus"

current_directory=${PWD}

hosting_directory="${current_directory}/workers/features"

rm -rf "${current_directory}/workers/features/${feature_name}"

dotnet run \
--application "ide-management" \
--command "close" \
--ide-execute-file-location  "" \
--application-location  "" \
--templates-directory "environment-variables-template-files" \
--destination-directory  "environment-variables-files" \
--environment-variables-source-directory  "environment-variables-source"  \
--feature-name "${feature_name}" \
--executive-file-directory "${current_directory}/bin/Debug/net8.0/cross-application-feature-development-management"  \
--scripts-directory "${current_directory}/scripts" \
--repository-directory "${current_directory}/.." \
--hosting-directory "${hosting_directory}" \
--host-application-name "${host_application_name}" \
--guest-application-name "${guest_application_name}"