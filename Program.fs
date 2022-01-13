// TODO
// Add worker for file convertation from xlsx to csv using Gnumeric 
// Flow: 1) Download file 2) Convert file 3) Save with name foo_cuurent_date.csv 4) Remove old file
// 5) If file doesnt ready and user made request, send response "Sorry service anavailable."
module Program =

    open Parser
    open System

    let some x z = printf "%A=x, %A=z" x z

    let queryByParams (line:string[]) path = 
        match line.Length with
        | 0 -> printf "Not enought values"
        | 1 | 2 -> 
                line
                |> buildSearchObject
                |> doSearch <| path
                |> Seq.iter (printf "%A\n")
        | _ -> printf "Too much values. Only 2 values require.\n"

    let parseParams (input:string) = 
        let parser (value:string) = value.Split [|','|] |> Array.map (fun (x:string) -> x.Trim())
        
        match input with
        | "" -> [||]
        | _ -> parser input

    [<EntryPoint>]
    let main argv = 
        let rec readParams (input:string) filePath = 
            input |> parseParams |> queryByParams <| filePath
            readParams (Console.ReadLine()) filePath

        printf "Enter band and/or album.\nBand and album name must be comma separated.\n"
        match argv.Length with
        | 0 -> printf "File path must be set"
        | _ -> readParams (Console.ReadLine()) argv[0]
        0
