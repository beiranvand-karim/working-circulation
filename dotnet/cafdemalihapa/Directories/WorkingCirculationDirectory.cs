namespace cafdemalihapa.Directories
{
    public class WorkingCirculationDirectory
    {
        public string GetName()
        {
            var workingCirculationDirectoryName = GetPath();

            var environmentVariablesManagementDirectoryName =
                Path.Combine(workingCirculationDirectoryName, "EnvironmeentVariablesManagement");

            return environmentVariablesManagementDirectoryName;
        }

        private string GetPath()
        {
            const string repositoryDirectoryNameKey = "--repository-directory";
            var workingCirculationDirectoryName =
                Path.Combine(CommandLineArgs.GetByKey(repositoryDirectoryNameKey), "WorkingCirculation");
            return workingCirculationDirectoryName;
        }
    }
}
