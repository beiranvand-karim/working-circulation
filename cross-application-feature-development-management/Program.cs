
using cross_application_feature_development_management;
using cross_application_feature_development_management.Combiners.Classes;
using cross_application_feature_development_management.Combiners.Interfaces;
using cross_application_feature_development_management.Dirctories;
using cross_application_feature_development_management.Dirctories.Classes;
using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory;
using cross_application_feature_development_management.Dirctories.Feature.AutomationsDirectory.BatchScriptFilesDirectory;
using cross_application_feature_development_management.Dirctories.Feature.EnvironmentVariablesTemplateFiles;
using cross_application_feature_development_management.Dirctories.Interfaces;
using cross_application_feature_development_management.Helpers.Classes;
using cross_application_feature_development_management.Helpers.Interfaces;
using cross_application_feature_development_management.Interfaces;
using cross_application_feature_development_management.Names.Classses;
using cross_application_feature_development_management.Names.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

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
                services.AddTransient<ICrossApplicationFeatureDevelopmentManagement, CrossApplicationFeatureDevelopmentManagement>();
                services.AddTransient<ICommandLineArgs, CommandLineArgs>();
                services.AddTransient<IScriptsDirectory, ScriptsDirectory>();
                services.AddTransient<ITemplatesDirectory, TemplatesDirectory>();
                services.AddTransient<IHostingDirectory, HostingDirectory>();
                services.AddTransient<IFeatureNameDirectory, FeatureNameDirectory>();
                services.AddTransient<IEnvironmentVariablesFilesDirectory, EnvironmentVariablesFilesDirectory>();
                services.AddTransient<ITargetDirectory, TargetDirectory>();
                services.AddTransient<IWorkingCirculationDirectory, WorkingCirculationDirectory>();
                services.AddTransient<IEnvironmentVariablesSourceDirectory, EnvironmentVariablesSourceDirectory>();
                services.AddTransient<ISomethingFeatureNameDirectory, SomethingFeatureNameDirectory>();
                services.AddTransient<IDirectoriesNameToKeyMap, DirectoriesNameToKeyMap>();
                services.AddTransient<IPowerShellScriptsDirectory, PowerShellScriptsDirectory>();
                services.AddTransient<IBatchScriptsDicrectory, BatchScriptsDicrectory>();
                services.AddTransient<IHostApplicationName, HostApplicationName>();
                services.AddTransient<IGuestApplicationName, GuestApplicationName>();
                services.AddTransient<ISomething, Something>();
                services.AddTransient<IAddToStartupScript, AddToStartupScript>();
                services.AddTransient<IStringHelpers, StringHelpers>();
                services.AddTransient<IDirectories, Directories>();
                services.AddTransient<IFeatureName, FeatureName>();
                services.AddTransient<INotePadPlusPlusOpenAll, NotePadPlusPlusOpenAll>();
                services.AddTransient<IBatchScriptFilesDirectory, BatchScriptFilesDirectory>();
                services.AddTransient<IAutomationsDirectory, AutomationsDirectory>();
                services.AddTransient<INotePadPlusPlusAllClose, NotePadPlusPlusAllClose>();
                services.AddTransient<INotepadPlusPlusMultitudeAllOrderReverseActionOpen, NotepadPlusPlusMultitudeAllOrderReverseActionOpen>();
            })
            .UseSerilog()
            .Build();

        var svc = ActivatorUtilities.CreateInstance<CrossApplicationFeatureDevelopmentManagement>(host.Services);
        svc.Run();
    }

    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Prodcution"}.json", optional: true)
            .AddEnvironmentVariables();
    }
}