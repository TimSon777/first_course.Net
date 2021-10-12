module hw3.ErrorMessages
let isErrorCodeDisplayErrorMessage code (args:string[]) =
    if code = ErrorCode.Correct then false
    else match code with
         | ErrorCode.WrongArgLength -> printf $"The program requires 3 arguments, but was {args.Length}"
         | ErrorCode.WrongArgFormatInt -> printf $"Value(s) is/are not int: {args.[0]}, {args.[2]}"
         | _ -> printf $"Value is not operation: {args.[1]}"
         true