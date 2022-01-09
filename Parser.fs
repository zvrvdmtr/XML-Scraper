module Parser 

    open FSharp.Data

    type SearchObject = {Musician: string; Album: string}

    let file = CsvFile.Load("/Users/zverev/Documents/fsharp/text.csv")

    let objects = file.Rows |> Seq.map (fun i -> {Musician = i[1]; Album = i[2]})

    let buildObject (argv: string[]) = 
        match argv.Length with
        | 1 -> {Musician = argv[0]; Album = ""}
        | 2 -> {Musician = argv[0]; Album = argv[1]}
        | _ -> {Musician = ""; Album = ""}

    let IsAlbumEqual album = List.filter (fun x -> x.Album = album)

    let IsMusicianEqual musician = List.filter (fun x -> x.Musician = musician)

    let IsObjectsEqual completeObject = List.filter (fun x -> x = completeObject)

    let search object = 
        match object with
        | {Musician = ""; Album = ""} -> []
        | {Musician = ""} -> IsAlbumEqual object.Album (Seq.toList objects)
        | {Album = ""} -> IsMusicianEqual object.Musician (Seq.toList objects)
        | _ -> IsObjectsEqual object (Seq.toList objects)