namespace cross_application_feature_development_management.Combiners.Interfaces
{
    public interface IAddToStartupScript
    {
        public Dictionary<string, string> PairUpVariablesWithTheirValue(
            string fileNamePath,
            Dictionary<string, string> environmentVariablesSourceDictionary
        );
    }
}