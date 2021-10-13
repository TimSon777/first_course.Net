module hw4.ErrorMessages

let getErrorMessage code (args:string[]) =
    match code with
    | ErrorCode.WrongArgLength -> $"The program requires 3 arguments, but was {args.Length}"
    | ErrorCode.WrongArgFormatValue -> $"Value(s) is/are not int: {args.[0]}, {args.[2]}"
    | _ -> $"Value is not operation: {args.[1]}"
