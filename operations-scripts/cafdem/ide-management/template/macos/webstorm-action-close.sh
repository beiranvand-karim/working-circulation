#!/bin/bash

feature_name="wonderful feature"
current_directory=${PWD}
hosting_directory="${current_directory}/workers/features"

dotnet run \
--application "ide-management" \
--command "close" \
--ide-execute-file-location  "" \
--application-location  "" \
--feature-name "${feature_name}" \
--hosting-directory "${hosting_directory}"