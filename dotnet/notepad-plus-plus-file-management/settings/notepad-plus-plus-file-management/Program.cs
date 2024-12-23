﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using notepad_plus_plus_file_management;
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
                services.AddTransient<IProcessManager, ProcessManager>();
                services.AddTransient<INotePadPlusPlus, NotePadPlusPlus>();
                services.AddTransient<IDirectoryOperations, DirectoryOperations>();
            })
            .UseSerilog()
            .Build();

        var svc = ActivatorUtilities.CreateInstance<ProcessManager>(host.Services);
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