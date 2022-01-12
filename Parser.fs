module Parser

    open FSharp.Data

    type Record = {Band: string; Album: string}

    let file = CsvFile.Load("/Users/zverev/Documents/fsharp/text.csv")

    let objects = file.Rows |> Seq.map (fun i -> {Band = i[1]; Album = i[2]})

    let buildObject (argv: string[]) = 
        match argv.Length with
        | 0 -> {Band = ""; Album = ""}
        | 1 -> {Band = argv[0]; Album = ""}
        | _ -> {Band = argv[0]; Album = argv[1]}

    let IsAlbumEqual album =
        List.filter (fun x -> x.Album = album)

    let IsBandEqual musician =
        List.filter (fun x -> x.Band = musician)

    let IsObjectsEqual completeObject = 
        List.filter (fun x -> x = completeObject)

    let search object = 
        match object with
        | {Band = ""; Album = ""} -> []
        | {Band = ""} -> IsAlbumEqual object.Album (Seq.toList objects)
        | {Album = ""} -> IsBandEqual object.Band (Seq.toList objects)
        | _ -> IsObjectsEqual object (Seq.toList objects)