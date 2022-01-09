module Program =

    open Parser

    [<EntryPoint>]
    let main argv = 
        let obj = buildObject argv
        obj |> search |> Seq.iter (printf "%A")
        0