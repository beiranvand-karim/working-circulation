using Microsoft.Extensions.Configuration;

namespace notepad_plus_plus_file_management
{
    public class NotePadPlusPlus : INotePadPlusPlus
    {
        private readonly IConfiguration configuration;
        private string? exceutiveFileLocation;
        private string? openeeFilesContainingDirectoryLocation;

        public NotePadPlusPlus(IConfiguration configuration)
        {
            this.configuration = configuration;
            BindToSettingsSection();
        }

        public void BindToSettingsSection()
        {
            configuration.GetSection("NotePadPlusPlus").Bind(this);
        }

        public string? ExceutiveFileLocation { get => exceutiveFileLocation; set => exceutiveFileLocation = value; }
        public string? OpeneeFilesContainingDirectoryLocation { get => openeeFilesContainingDirectoryLocation; set => openeeFilesContainingDirectoryLocation = value; }

        public string GetExceutiveFileLocation()
        {
            return ExceutiveFileLocation ?? "no such directory";
        }

        public string GetOpeneeFilesContainingDirectoryLocation()
        {
            return OpeneeFilesContainingDirectoryLocation ?? "no such directory";
        }
    }
}