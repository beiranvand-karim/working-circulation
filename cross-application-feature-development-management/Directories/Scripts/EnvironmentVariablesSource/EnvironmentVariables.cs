namespace cross_application_feature_development_management.Directories.Scripts.EnvironmentVariablesSource
{
    public class EnvironmentVariables
    {
        public bool? IsRiderGuestApplicationRunningPermissionGrantable { get; set; }
        public bool? IsWebstormGuestClientappRunningPermissionGrantable { get; set; }
        public string? DockerCliLocation { get; set; }
        public string? ApplicationComposeFileLocation { get; set; }
        public string? StartupDirectoryLocation { get; set; }
        public string? DirectoryManagementExecutiveFileAddress { get; set; }
        public string? DirectoryManagementExecutiveFileAddressContainingDirectory { get; set; }
        public string? InfrastructureComposeFileLocation { get; set; }
    }
}