using cross_application_feature_development_management.Applications.Cafdem;
using cross_application_feature_development_management.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource;
using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles
{
    public class EnvironmentVariablesFilesDirectory(
            AutomationsDirectory automationsDirectory,
            CafdemTerminalCapturement cafdemTerminalCapturement,
            Something something,
            EnvironmentVariablesSourceDirectory environmentVariablesSourceDirectory
        )
    {
        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }

        public string GetPath()
        {
            var destinationDirectory = automationsDirectory.GetPath();
            var environmentVariablesFilesDirectory = Path.Combine(destinationDirectory, "environment-variables-files");
            return environmentVariablesFilesDirectory;
        }

        public Dictionary<string, string> PairUp()
        {
            Dictionary<string, string> environmentVariablesSourceDictionary;

            if (cafdemTerminalCapturement.IsFormatJson())
            {

                if (cafdemTerminalCapturement.IsFilementSplit())
                {
                    environmentVariablesSourceDictionary = something.PairUpEnvironmentVariablesSeparationFilement();
                }
                else
                {
                    environmentVariablesSourceDictionary =
                        something.GetAllEnvironmentVariablesAndValuesFromSourceJsonFile<EnvironmentVariables>(
                            environmentVariablesSourceDirectory.GetPath()
                        );
                }
            }
            else
            {
                environmentVariablesSourceDictionary =
                    something.GetAllEnvironmentVariablesAndValuesFromSourceFile(
                        environmentVariablesSourceDirectory.GetPath()
                    );
            }

            return environmentVariablesSourceDictionary;
        }

    }
}
