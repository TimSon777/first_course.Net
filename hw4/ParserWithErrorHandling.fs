module hw4.ParserWithErrorHandling

open MaybeBuilder

let checkArgLength (array: string[]) =
    match array.Length with
    | 3 -> Ok array
    | _ -> Error ErrorCode.WrongArgLength
    
let parseOperation (args:string[]):Result<string*Operation*string, ErrorCode> =
        match args.[1] with
        | "+" -> Ok (args.[0], Operation.Plus, args.[2])
        | "-" -> Ok (args.[0], Operation.Minus, args.[2])
        | "/" -> Ok (args.[0], Operation.Divide, args.[2])
        | "*" -> Ok (args.[0], Operation.Multiply, args.[2])
        | _ -> Error ErrorCode.WrongArgFormatOperation

let parseValues (arg1:string,op:Operation,arg2:string) =
    try Ok (arg1 |> decimal, op, arg2 |> decimal)
    with | _ -> Error ErrorCode.WrongArgFormatValue
    
let parse (args:string[]) =
    maybe {
        let! a = checkArgLength args
        let! b = parseOperation a
        let! c = parseValues b
        return c
    }
   