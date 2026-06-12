namespace cafdemwimu.console

open System.Runtime.CompilerServices
open Microsoft.Extensions.DependencyInjection
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.DirectoriesMultitude
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeJetbrains
open cafdemwimu.console.Directories.Hosting.Feature.Automations.EnvironmentVariablesTemplateFiles.IdeMicrosoft

[<Extension>]
type MultitudeServiceCollectionExtensions =
    [<Extension>]
    static member AddMultitudeServices(services: IServiceCollection) : IServiceCollection =
        services.AddSingleton<DirectoriesMultitudeServingOrderReverseActionOpen>() |> ignore
        services.AddSingleton<DirectoriesMultitudeCommandingOrderReverseActionOpen>() |> ignore
        services.AddSingleton<DirectoriesMultitudeCommandingOrderRectoActionOpen>() |> ignore
        services.AddSingleton<DirectoriesMultitudeCommandingOrderRectoActionShut>() |> ignore
        services.AddSingleton<DirectoriesMultitudeServingOrderRectoActionOpen>() |> ignore
        services.AddSingleton<DirectoriesMultitudeServingOrderRectoActionShut>() |> ignore
        services.AddTransient<IdeJetbrainsRiderMultitudePrimaryActionOpen>() |> ignore
        services.AddTransient<IdeJetbrainsRiderMultitudeSecondaryActionOpen>() |> ignore
        services.AddTransient<IdeJetbrainsRiderMultitudeTertiaryActionOpen>() |> ignore
        services.AddTransient<IdeJetbrainsWebstormMultitudePrimaryActionOpen>() |> ignore
        services.AddTransient<IdeJetbrainsWebstormMultitudeSecondaryActionOpen>() |> ignore
        services.AddTransient<IdeJetbrainsWebstormMultitudeTertiaryActionOpen>() |> ignore
        services.AddTransient<IdeJetbrainsWebstormMultitudePrimaryActionShut>() |> ignore
        services.AddTransient<IdeJetbrainsWebstormMultitudeSecondaryActionShut>() |> ignore
        services.AddTransient<IdeJetbrainsWebstormMultitudeTertiaryActionShut>() |> ignore
        services.AddTransient<IdeJetbrainsRiderMultitudePrimaryActionShut>() |> ignore
        services.AddTransient<IdeJetbrainsRiderMultitudeSecondaryActionShut>() |> ignore
        services.AddTransient<IdeJetbrainsRiderMultitudeTertiaryActionShut>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeDefaultMultitudePrimaryActionOpen>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeDefaultMultitudeSecondaryActionOpen>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeDefaultMultitudeTertiaryActionOpen>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeDefaultMultitudePrimaryActionShut>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeDefaultMultitudeSecondaryActionShut>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeDefaultMultitudeTertiaryActionShut>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeInsidersMultitudePrimaryActionOpen>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeInsidersMultitudeSecondaryActionOpen>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeInsidersMultitudeTertiaryActionOpen>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeInsidersMultitudePrimaryActionShut>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeInsidersMultitudeSecondaryActionShut>() |> ignore
        services.AddTransient<IdeMicrosoftVscodeInsidersMultitudeTertiaryActionShut>() |> ignore

        services
