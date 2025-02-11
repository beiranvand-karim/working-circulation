namespace cross_application_feature_development_management.Directories.Feature.AutomationsDirectory.OperationsDirectory
{
    public interface IOperationsDirectory
    {
        public string GetPath();
        public void Create();
    }
    public class OperationsDirectory(
        IAutomationsDirectory automationsDirectory
        ): IOperationsDirectory
    {
        private readonly IAutomationsDirectory automationsDirectory = automationsDirectory;

        public void Create()
        {
            var path = GetPath();
            Directory.CreateDirectory(path);
        }
        public string GetPath()
        {
            var directory = automationsDirectory.GetPath();
            var operationsDirectory = Path.Combine(directory, "operations");
            return operationsDirectory;
        }
    }
}