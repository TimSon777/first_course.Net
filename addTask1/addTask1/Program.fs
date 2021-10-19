module addTask1.Program

type MaybeBuilder() =
    member b.Zero() = None
    member b.Bind(x, f) =
        match x with
        | Some x -> f x
        | None   -> None
    member b.Return x = Some x
    
let maybe = MaybeBuilder()
[<EntryPoint>]
let main _ =
    let a = Some 1
    let b = Some 3
    let result = 
        maybe {
            let! v1 = a
            let! v2 = b
            return v1 + v2
        }
    printf $"{result}"
    0
