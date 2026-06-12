namespace cafdemwimu.console.Directories.Repository.Dotnet.Scripts.EnvironmentVariablesSource.SeparationFilement

open System

[<CLIMutable>]
type PrimaryApplicationSettings =
    { PrimaryApplicationLocation: string
      PrimaryClientappLocation: string
      PrimaryApplicationProjectLocation: string
      PrimaryApplicationProjectName: string }

[<CLIMutable>]
type SecondaryApplicationSettings =
    { SecondaryApplicationLocation: string
      SecondaryClientappLocation: string
      SecondaryApplicationProjectLocation: string
      SecondaryApplicationProjectName: string }

[<CLIMutable>]
type TertiaryApplicationSettings =
    { TertiaryApplicationLocation: string
      TertiaryApplicationProjectLocation: string
      TertiaryApplicationProjectName: string
      TertiaryClientappLocation: string }

[<CLIMutable>]
type MutantVariables =
    { IsRiderSecondaryApplicationRunningPermissionGrantable: Nullable<bool>
      IsWebstormSecondaryClientappRunningPermissionGrantable: Nullable<bool>
      PrimaryApplicationName: string
      SecondaryApplicationName: string
      IsOpeningFeatureSelfAddress: Nullable<bool>
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
      IsRiderTertiaryApplicationRunningPermissionGrantable: Nullable<bool>
      IsWebstormTertiaryClientappRunningPermissionGrantable: Nullable<bool>
      TertiaryApplicationName: string
      IsOpeningFendTertiaryAddress: Nullable<bool>
      IsOpeningBendTertiaryAddress: Nullable<bool>
      TertiaryApplication: TertiaryApplicationSettings }
