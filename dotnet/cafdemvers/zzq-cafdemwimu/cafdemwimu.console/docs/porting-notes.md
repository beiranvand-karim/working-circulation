# Porting notes: cafdemalihapa (C#) → cafdemwimu.console (F#)

Source project: `dotnet/cafdemalihapa`
Target project: `dotnet/cafdemvers/zzq-cafdemwimu/cafdemwimu.console`

The target replicates the source class-for-class, mirroring the C# folder tree
and namespaces. Only the root namespace changes: `cafdemalihapa` → `cafdemwimu.console`.

## Status by folder

| Source folder | Status | Target location | Notes |
|---|---|---|---|
| `Names` | ✅ Done | `Names/` | 6 classes |
| `Files` | ✅ Done | `Files/` | `FileService` (→ module) + `Executables/` |
| `Helpers` | ✅ Done | `Helpers/` | `StringHelpers` |
| `Directories` | ✅ Done | `Directories/` | 63 classes |
| `Applications` | ✅ Done | `Applications/` | Full tree: `ApplicationSwitcher`, `Applications`/`Commands`/`PathUtility`, `Cafdemalihapa/*`, `DirectoryManagement/*` (incl. the open-strategy hierarchy), `IdeManagement/*`, `NotepadPlusPlusFileManagement/*` |
| Root wiring | ✅ Done | project root | `DirectoryOperations`, `ServiceCollectionExtensions` + `MultitudeServiceCollectionExtensions` (DI), `Program` (Serilog + Generic Host), `appsettings.json`, `DirectoryOpenStrategies.md` |

`CommandLineArgs` (source root) is replicated at `CommandLineArgs.fs` in the
root namespace `cafdemwimu.console`.

## Build

```
dotnet build
```

Targets `net10.0`. `Program.fs` is the entry point (Generic Host + Serilog); it
resolves `ApplicationSwitcher` from the DI container and calls `Run()`.
`appsettings.json` is copied to the output directory.

Package references added during porting:

- `Microsoft.Extensions.Logging.Abstractions` — for `ILogger<T>` constructor injection.
- `Microsoft.Extensions.Hosting` — Generic Host, DI, configuration (incl. JSON config).
- `Newtonsoft.Json` — used by `Applications/Something.fs` (the source uses both
  Newtonsoft and `System.Text.Json`; both are preserved).
- `Serilog.Extensions.Hosting`, `Serilog.Settings.Configuration`, `Serilog.Sinks.Console`
  — logging, wired up in `Program.fs` (`UseSerilog`, `ReadFrom.Configuration`).

## Translation conventions (C# → F#)

| C# construct | F# translation |
|---|---|
| `public class Foo(Dep dep)` (primary-ctor DI) | `type Foo(dep: Dep) =` |
| `public static class Foo` | `[<AbstractClass; Sealed>] type Foo private () =` with `static member`s, or a `module` for free functions |
| `static class` with stateless methods (`FileService`) | F# `module` |
| `switch (key) { case ...: }` | `match key with \| "..." -> ...` |
| `dict.TryGetValue(k, out var v)` | `match dict.TryGetValue k with \| true, v -> ... \| _ -> ()` |
| `while (reader.ReadLine() is { } line)` | `let mutable line = reader.ReadLine()` + `while not (isNull line) do ...; line <- reader.ReadLine()` |
| `using var s = ...` | `use s = ...` |
| `value ?? ""` on nullable string | `orEmpty value` (helper in `Directories/NullHelpers.fs`) |
| string interpolation `$"{x}"` | same `$"{x}"` |
| `line.Split("=")` | `line.Split('=')` (char overload) |
| `public bool? X { get; set; }` POCO | `[<CLIMutable>]` record with `System.Nullable<bool>` / `string` fields |
| method overloads (same name, diff arity) | keep as a `type` with `static member` overloads — **not** a `module` (modules can't overload) |
| `this string` extension methods (`Applications`, `Commands`) | `[<Extension>]` static members on a class; fluent `value.IsX()` call sites preserved |
| `interface` / `abstract class` + `virtual` (`IDirectoryOpenStrategy`, `DirectoryOpenStrategy`, strategies) | F# `type I = abstract …`, `[<AbstractClass>]` with `abstract`/`default`, `inherit` + `override` |
| `dynamic` COM interop (`FolderViewConfigurator`) | reflection late-binding (`Type.InvokeMember` with `BindingFlags`) — see `ComLateBinding` module |
| reference type that JSON deserialization may return as `null` | `[<AllowNullLiteral>]` on the class so `isNull` is allowed (`IdeProcessInformationGroup`, `ProcessInformationGroup`) |
| `init`-only / nullable POCO props (`IdeProcessInformation`, `ProcessInformation`) | `[<CLIMutable>]` record with `System.Nullable<int>` / `string` fields |

### Helper

`Directories/NullHelpers.fs` defines `orEmpty (s: string) = if isNull s then "" else s`,
used to mirror the source's defensive `?? ""` on `Path.GetDirectoryName` and
dictionary-lookup results.

## Gotchas

- **F# is compile-order-sensitive.** Files must be listed in the `.fsproj` in
  dependency order (a type must be defined before it is used). The dependency
  graph of `Directories` is a DAG, so a topological ordering exists — see the
  `<Compile>` ordering in `cafdemwimu.console.fsproj`. There are **no circular
  type dependencies**; if one is ever introduced, F# will require a `rec`
  namespace or `and`-joined types.

- **Faithful quirks preserved from the source** (intentionally not "fixed"):
  - The misspelled type name `RunPrimayApplication`.
  - `DirectoriesMultitudeStartupActionOpen` logs its error under the message
    prefix `EnvironmentVariablesSourceFilesDirectory:` (copy-paste artifact in
    the original).
  - `CommandsDirectory.GetPath()` builds the *commands* path but the original
    names the local `operationsDirectory`.
  - The empty stub `Files/Executables/NotePadPlusPlusFileManagementExecutiveFile`
    is replicated as a namespace-only file.

- **`CAFDEM_…_CONTAINING_DIRECTORY` handling differs per file.** Some source
  processors use an `if (TryGetValue)` form (adds the key only when the source
  value is present); others use the unconditional form (always adds, possibly
  `""`). Each F# file matches its original's form rather than normalizing.

- **`Something` (Applications)** depends on `PersistentVariablesFile` /
  `MutantVariablesFile`, which live in the `Directories` tree — so it is compiled
  *after* those.

- **`Commands` namespace.** In the source, `DirectoryManagement/Commands.cs` is
  declared in namespace `cafdemalihapa.Applications` (not `…DirectoryManagement`),
  despite its folder. The F# port keeps that: `Applications/DirectoryManagement/Commands.fs`
  declares `namespace cafdemwimu.console.Applications`.

- **`SingleOrDefault` → `Seq.tryExactlyOne`** in `IdeProcessManagement.Close`.
  Minor semantic difference: C#'s `SingleOrDefault` throws when more than one
  element matches, whereas `Seq.tryExactlyOne` returns `None`. Match logic is
  otherwise identical.

- **`IEnumerable<IDirectoryOpenStrategy>` injection.** `Opening` receives the
  strategy set and picks the first whose `CanHandle()` is true
  (`Seq.tryFind`), mirroring the source's `FirstOrDefault`. All three strategies
  are registered against the `IDirectoryOpenStrategy` interface in
  `ServiceCollectionExtensions`.

- **DI registration** (`ServiceCollectionExtensions` / `MultitudeServiceCollectionExtensions`)
  is ported as `[<Extension>]` `AddServices` / `AddMultitudeServices` on
  `IServiceCollection`. Generic registrations translate directly:
  `services.AddTransient<Foo>() |> ignore`, `services.AddSingleton<IFace, Impl>() |> ignore`.
  Lifetimes (Transient vs Singleton) match the source exactly.

- **`Program.fs` must be compiled last** and carries the single `[<EntryPoint>]`
  `main`. `BuildConfig` reads `appsettings.json` + `appsettings.{ENV}.json` +
  environment variables; the host resolves `ApplicationSwitcher` via
  `ActivatorUtilities.CreateInstance`.
