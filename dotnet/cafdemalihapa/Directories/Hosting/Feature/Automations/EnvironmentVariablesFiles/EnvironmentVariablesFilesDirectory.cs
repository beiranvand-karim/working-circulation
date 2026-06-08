using cafdemalihapa.Applications;

namespace cafdemalihapa.Directories.Hosting.Feature.Automations.EnvironmentVariablesFiles
{
    public class EnvironmentVariablesFilesDirectory(
            AutomationsDirectory automationsDirectory,
            Something something
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

            environmentVariablesSourceDictionary = something.PairUpEnvironmentVariablesSeparationFilement();

            return environmentVariablesSourceDictionary;
        }

    }
}
