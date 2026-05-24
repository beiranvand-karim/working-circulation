using cafdemalihapa.Applications.Cafdem;
using cafdemalihapa.Directories.Repository.Cafdem.Scripts.EnvironmentVariablesSource;
using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.HostingDirectory.FeatureDirectory.AutomationsDirectory.EnvironmentVariablesFiles
{
    public class EnvironmentVariablesFilesDirectory(
            AutomationsDirectory automationsDirectory,
            CafdemalihapaCapturement cafdemTerminalCapturement,
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
