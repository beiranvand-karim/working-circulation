#!/bin/bash

feature_name="wonderful feature"
host_application_name="augustus"
guest_application_name="decimus"

current_directory=${PWD}

hosting_directory="${current_directory}/workers/features"

rm -rf "${current_directory}/workers/features/${feature_name}"

dotnet run \
--application "cross-application-feature-development-management" \
--command "create-scripts" \
--format "json" \
--filement "unite" \
--feature-name "${feature_name}" \
--executive-file-directory "${current_directory}/bin/Debug/net8.0/cross-application-feature-development-management"  \
--scripts-directory "${current_directory}/scripts" \
--hosting-directory "${hosting_directory}" \
--host-application-name "${host_application_name}" \
--guest-application-name "${guest_application_name}"