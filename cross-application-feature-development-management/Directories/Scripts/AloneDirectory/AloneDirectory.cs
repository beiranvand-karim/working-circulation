using cross_application_feature_development_management.Names;

namespace cross_application_feature_development_management.Directories.Scripts.AloneDirectory
{
    public class AloneDirectory
    (
        GuestApplicationName guestApplicationName,
        ScriptsDirectory scriptsDirectory
    )
    {
        public string GetName()
        {
            var primaryDirectory =
                Path.Combine(
                    scriptsDirectory.GetPath(),
                    "primary"
                );

            var templateSourceDirectory =
                Path.Combine(
                    primaryDirectory,
                    "environment-variables-template-files"
                );

            return templateSourceDirectory;
        }

        public string AloneOrDouble()
        {
            var x = guestApplicationName.GetName();
            return x.Contains("couldn") ? "alone" : "double";
        }

        public bool IsAlone()
        {
            return AloneOrDouble() == "alone";
        }
    }
}