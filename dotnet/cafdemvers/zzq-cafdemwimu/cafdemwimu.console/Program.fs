module cafdemwimu.console.Program

open System
open System.IO
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Serilog
open cafdemwimu.console
open cafdemwimu.console.Applications

let private BuildConfig (builder: IConfigurationBuilder) =
    let environment =
        match Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") with
        | null -> "Production"
        | value -> value

    builder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($"appsettings.{environment}.json", true)
        .AddEnvironmentVariables()
    |> ignore

[<EntryPoint>]
let main args =
    let builder = ConfigurationBuilder()
    BuildConfig builder

    Log.Logger <-
        LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger()

    let host =
        Host.CreateDefaultBuilder()
            .ConfigureServices(fun context services -> services.AddServices() |> ignore)
            .UseSerilog()
            .Build()

    let svc = ActivatorUtilities.CreateInstance<ApplicationSwitcher>(host.Services)
    svc.Run()
    0
