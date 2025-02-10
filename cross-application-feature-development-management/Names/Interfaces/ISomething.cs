namespace cross_application_feature_development_management.Names.Interfaces
{
    public interface ISomething
    {
        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceJsonFile(
            string environmentVariablesSourceDirectory
        );

        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceFile(
            string environmentVariablesSourceDirectory
        );
        
        public Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        );
    }
}