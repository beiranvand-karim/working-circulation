namespace cross_application_feature_development_management
{
    public interface ISomethingFeatureNameDirectory
    {
        public Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        );
    }
}