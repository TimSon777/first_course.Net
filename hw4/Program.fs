module hw4.Program
    
open ParserWithErrorHandling
open Calculator
open ErrorMessages
open MaybeBuilder

[<EntryPoint>]
let main args =
    let result = maybe {
        let! p = parse args
        let res = calculate p
        return res
    }

    match result with
    | Ok value ->
        printf $"{value}"
        0
    | Error code ->
        printf $"%s{getErrorMessage code args}"
        int code