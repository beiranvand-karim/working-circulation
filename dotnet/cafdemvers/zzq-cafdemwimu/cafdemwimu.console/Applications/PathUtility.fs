namespace cafdemwimu.console.Applications

open System.IO

module PathUtility =

    type SlashStyle =
        | AutoByOS = 0
        | ForceSlash = 1
        | ForceBackslash = 2

    let NormalizeSlashes (path: string, style: SlashStyle) =
        match style with
        | SlashStyle.ForceSlash -> path.Replace("\\", "/")
        | SlashStyle.ForceBackslash -> path.Replace("/", "\\")
        | _ ->
            let correctSlash = Path.DirectorySeparatorChar
            let wrongSlash = if correctSlash = '\\' then '/' else '\\'
            path.Replace(wrongSlash, correctSlash)
