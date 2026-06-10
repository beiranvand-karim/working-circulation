namespace cafdemwimu.console.Files

open System
open System.IO

module FileService =
    let CreateNumberedFiles (path: string) =
        let dashLine = String('-', 40)
        let lines =
            seq { 0 .. 19 }
            |> Seq.collect (fun index ->
                if index = 0 then [ dashLine ]
                else [ ""; ""; ""; dashLine ])
            |> List.ofSeq

        for number in 1 .. 10 do
            let filePath = Path.Combine(path, number.ToString("D3"))
            File.WriteAllLines(filePath, lines)
