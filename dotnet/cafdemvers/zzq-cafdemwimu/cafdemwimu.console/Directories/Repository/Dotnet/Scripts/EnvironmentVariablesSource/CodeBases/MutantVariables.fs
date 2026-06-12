namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource

open System

[<CLIMutable>]
type PrimaryApplicationSettings =
    { PrimaryApplicationLocation: string
      PrimaryClientappLocation: string
      PrimaryApplicationProjectLocation: string
      PrimaryApplicationProjectName: string
      PrimaryApplicationName: string }

[<CLIMutable>]
type SecondaryApplicationSettings =
    { SecondaryApplicationLocation: string
      SecondaryClientappLocation: string
      SecondaryApplicationProjectLocation: string
      SecondaryApplicationProjectName: string
      SecondaryApplicationName: string }

[<CLIMutable>]
type TertiaryApplicationSettings =
    { TertiaryApplicationLocation: string
      TertiaryApplicationProjectLocation: string
      TertiaryApplicationProjectName: string
      TertiaryClientappLocation: string
      TertiaryApplicationName: string }

[<CLIMutable>]
type MutantVariables =
    { IsOpeningFeatureSelfAddress: Nullable<bool>
      IsOpeningAutomationsDirectory: Nullable<bool>
      IsOpeningCommandsDirectory: Nullable<bool>
      IsOpeningEnvironmentVariablesFilesDirectory: Nullable<bool>
      IsOpeningOperationsDirectory: Nullable<bool>
      IsOpeningDataDirectory: Nullable<bool>
      IsOpeningFendPrimaryAddress: Nullable<bool>
      IsOpeningFendSecondaryAddress: Nullable<bool>
      IsOpeningBendAddress: Nullable<bool>
      IsOpeningBendPrimaryAddress: Nullable<bool>
      IsOpeningBendSecondaryAddress: Nullable<bool>
      IsOpeningCallsAddress: Nullable<bool>
      IsOpeningToolsAddress: Nullable<bool>
      IsOpeningNotesMessagesAddress: Nullable<bool>
      IsOpeningWebLinksAddress: Nullable<bool>
      IsOpeningFendAddress: Nullable<bool>
      PrimaryApplication: PrimaryApplicationSettings
      SecondaryApplication: SecondaryApplicationSettings
      IsOpeningFendTertiaryAddress: Nullable<bool>
      IsOpeningBendTertiaryAddress: Nullable<bool>
      TertiaryApplication: TertiaryApplicationSettings }
