using cafdemalihapa.Names;

namespace cafdemalihapa.Directories.Repository.Cafdem.Scripts.AloneDirectory
{
    public class AloneDirectory
    (
        SecondaryApplication secondaryApplication,
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
            var x = secondaryApplication.GetName();
            return x.Contains("couldn") ? "alone" : "double";
        }

        public bool IsAlone()
        {
            return AloneOrDouble() == "alone";
        }
    }
}