// Add worker for file convertation from xlsx to csv using Gnumeric 
// Flow: 1) Download file 2) Convert file 3) Save with name foo_cuurent_date.csv 4) Remove old file
// 5) If file doesnt ready and user made request, send response "Sorry service anavailable."
// Add config for csv file path for parsing
// Add command line flags "all" - for all matching rows, "first" - only first matching row
module Program =

    open Parser
    open System

    let queryByParams (line:string[]) = 
        match line.Length with
        | 0 -> printf "Not enought values"
        | 1 | 2 -> 
                line
                |> buildObject
                |> search
                |> Seq.iter (printf "%A\n")
        | _ -> printf "Too much values. Only 2 values require.\n"

    let parseParams (input:string) = 
        let parser (value:string) = value.Split [|','|] |> Array.map (fun (x:string) -> x.Trim())
        
        match input with
        | "" -> [||]
        | _ -> parser input

    [<EntryPoint>]
    let main argv = 
        printf "Enter band and/or album.\nBand and album name must be comma separated.\n"

        let rec readParams (input:string) = 
            input |> parseParams |> queryByParams
            readParams (Console.ReadLine())

        readParams (Console.ReadLine())
        0
