namespace cross_application_feature_development_management.Names.Interfaces
{
    public interface ISomething
    {
        public Dictionary<string, string> GetAllEnvironmentVariablesAndValuesFromSourceFile(
    string environmentVariablesSourceDirectory
);
    }
}