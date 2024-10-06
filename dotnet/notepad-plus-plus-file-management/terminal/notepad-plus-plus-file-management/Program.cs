using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using notepad_plus_plus_file_management.Interfaces;
using notepad_plus_plus_file_management.Dirctories.Interfaces;
using notepad_plus_plus_file_management.Dirctories.Classes;
using notepad_plus_plus_file_management.Combiners.Interfaces;
using notepad_plus_plus_file_management.Combiners.Classes;
using notepad_plus_plus_file_management.Files.Executabes.Interfaces;
using notepad_plus_plus_file_management.Files.Executabes.Classes;
using notepad_plus_plus_file_management.Helpers.Interfaces;
using notepad_plus_plus_file_management.Helpers.Classes;
using notepad_plus_plus_file_management.Dirctories.Feature.AutomationsDirectory;
using notepad_plus_plus_file_management.Dirctories.Feature.AutomationsDirectory.ProcessesMetaDataDirectory;

namespace notepad_plus_plus_file_management
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IProcessManager, ProcessManager>();
                    services.AddTransient<INotePadPlusPlus, NotePadPlusPlus>();
                    services.AddTransient<IDirectoryOperations, DirectoryOperations>();
                    services.AddTransient<ICommandLineArgs, CommandLineArgs>();
                    services.AddTransient<IFeatureNameDirectory, FeatureNameDirectory>();
                    services.AddTransient<IHostingDirectory, HostingDirectory>();
                    services.AddTransient<IDirectoriesNameToKeyMap, DirectoriesNameToKeyMap>();
                    services.AddTransient<IFrontEndHostDirectory, FrontEndHostDirectory>();
                    services.AddTransient<IFrontEndGuestDirectory, FrontEndGuestDirectory>();
                    services.AddTransient<INotesAndMessagesDirectory, NotesAndMessagesDirectory>();
                    services.AddTransient<IStringHelpers, StringHelpers>();
                    services.AddTransient<IAutomationsDirectory, AutomationsDirectory>();
                    services.AddTransient<IProcessesMetaDataDirectory, ProcessesMetaDataDirectory>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<CommandSwitcher>(host.Services);
            svc.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder) => builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Prodcution"}.json", optional: true)
                .AddEnvironmentVariables();
    }
}