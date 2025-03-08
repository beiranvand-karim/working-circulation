#!/bin/bash

hosting_directory=${PWD}

cd /Users/karimbeiranvand/Documents/GitHub/working-circulation/cross-application-feature-development-management/bin/Debug/net8.0

./cross-application-feature-development-management \
--templates-directory "environment-variables-template-files" \
--destination-directory  "environment-variables-files" \
--environment-variables-source-directory  "environment-variables-source"  \
--feature-name "wonderful feature" \
--executive-file-directory "/cross-application-feature-development-management/bin/Debug/net8.0/cross-application-feature-development-management"  \
--scripts-directory "/Users/karimbeiranvand/Documents/GitHub/working-circulation/cross-application-feature-development-management/scripts" \
--repository-directory "/Users/karimbeiranvand/Documents/GitHub/working-circulation" \
--hosting-directory "${hosting_directory}" \
--host-application-name "augustus" \
--guest-application-name "julius"