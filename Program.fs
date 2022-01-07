type SearchObject = {Musician: string; Album: string}

let objects = [
    {Musician = "Red Hot chili Peppers"; Album = "Californication"}
    {Musician = "The Beatles"; Album = "Let It Be"}
    {Musician = "Nirvana"; Album = "Nevermind"}
    {Musician = "Nirvana"; Album = "In Utero"}
    {Musician = "The Stooges"; Album = "Raw Power"}
]

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
    | {Musician = ""} -> IsAlbumEqual object.Album objects
    | {Album = ""} -> IsMusicianEqual object.Musician objects
    | _ -> IsObjectsEqual object objects

[<EntryPoint>]
let main argv = 
    let obj = buildObject argv
    obj |> search |> Seq.iter (printf "%A")
    0