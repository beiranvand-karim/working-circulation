# Directory Open Strategies

Source: [`Applications/DirectoryManagement/DirectoryOpenStrategies/`](Applications/DirectoryManagement/DirectoryOpenStrategies/)

Opening a directory in the OS file explorer differs per platform. That folder isolates
those differences behind the **Strategy** pattern, with a **Template Method** base class
removing the duplicated process-launching boilerplate.

## Why

The original `Opening.OpenDirectories(string path)` was a three-branch `if / else if`
chain (macOS / Windows / Linux). Each branch launched a `Process` with the same
configuration and only two real differences:

| Platform | Executable     | Path argument                                 |
|----------|----------------|-----------------------------------------------|
| macOS    | `open`         | path as-is                                    |
| Windows  | `explorer.exe` | normalized to back-slashes (`ForceBackslash`) |
| Linux    | `xdg-open`     | path as-is                                    |

Everything else — `UseShellExecute = false`, `CreateNoWindow = true`, `Start()`, and the
logging — was duplicated three times.

## Design

```
        IDirectoryOpenStrategy            <-- contract: CanHandle() + Open(path)
                  ^
                  |
        DirectoryOpenStrategy             <-- abstract; Template Method Open(path)
          (owns the Process skeleton)         declares: FileName, TransformPath(path)
          ^         ^           ^
          |         |           |
        Mac…    Windows…      Linux…       <-- concrete strategies (one per OS)
```

- **`IDirectoryOpenStrategy`** — the contract. `CanHandle()` reports whether the strategy
  matches the current OS; `Open(path)` launches the explorer.
- **`DirectoryOpenStrategy`** (abstract, Template Method) — implements `Open(path)` once:
  it transforms the path, configures and starts the `Process`, and logs. Subclasses supply
  only what varies:
  - `FileName` (abstract) — the executable to run.
  - `TransformPath(path)` (`default`) — defaults to pass-through; override when a platform
    needs a different path format.
- **`MacDirectoryOpenStrategy` / `WindowsDirectoryOpenStrategy` / `LinuxDirectoryOpenStrategy`**
  — each declares its `FileName` and `CanHandle()`. Only Windows overrides `TransformPath`
  to force back-slashes (Explorer rejects forward-slash paths).

## Selection & wiring

All three strategies are registered against the `IDirectoryOpenStrategy` interface in
[`ServiceCollectionExtensions`](ServiceCollectionExtensions.fs):

```fsharp
services.AddSingleton<IDirectoryOpenStrategy, MacDirectoryOpenStrategy>() |> ignore
services.AddSingleton<IDirectoryOpenStrategy, WindowsDirectoryOpenStrategy>() |> ignore
services.AddSingleton<IDirectoryOpenStrategy, LinuxDirectoryOpenStrategy>() |> ignore
```

`Opening` injects them as `IEnumerable<IDirectoryOpenStrategy>` and picks the first whose
`CanHandle()` is `true`:

```fsharp
member _.OpenDirectories(path: string) =
    let strategy = directoryOpenStrategies |> Seq.tryFind (fun s -> s.CanHandle())

    match strategy with
    | None ->
        logger.LogWarning("Opening: no directory-open strategy supports the current operating system.")
    | Some strategy ->
        strategy.Open(path)
```

## Adding a new platform

1. Add a type inheriting from `DirectoryOpenStrategy`.
2. Set `FileName`, implement `CanHandle()`, and override `TransformPath` if the path format
   differs.
3. Register it as `IDirectoryOpenStrategy` in `ServiceCollectionExtensions`.

No change to `Opening` is required.
