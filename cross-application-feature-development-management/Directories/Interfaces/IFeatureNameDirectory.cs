namespace cross_application_feature_development_management.Directories.Interfaces
{
    public interface IFeatureNameDirectory
    {
        public void CreateSelf();
        public string GetPath();
    }
}