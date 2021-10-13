module Tests.ParserTests

open Xunit
open hw4
    
let argsForCheckLength =
    [|
        [|"1";"2";"3"|]
        [|"1";"2";"3";"4"|]
    |]
    
[<Theory>]
[<InlineData(0)>]
[<InlineData(1)>]
let _checkArgLength i =
    let result = ParserWithErrorHandling.checkArgLength argsForCheckLength.[i]
    match result with
    | Ok ok -> Assert.Equal(3, ok.Length)
    | Error error -> Assert.Equal(error, ErrorCode.WrongArgLength)


let argsForParseOperation =
    [|
        [|"1";"+";"2"|]
        [|"1";"-";"2"|]
        [|"1";"/";"2"|]
        [|"1";"*";"2"|]
        [|"1";"no";"2"|]
    |]
    
[<Theory>]
[<InlineData(0, Operation.Plus)>]
[<InlineData(1, Operation.Minus)>]
[<InlineData(2, Operation.Divide)>]
[<InlineData(3, Operation.Multiply)>]
[<InlineData(4, Operation.Plus)>]
let _parseOperation i expected =
    let result = ParserWithErrorHandling.parseOperation argsForParseOperation.[i]
    match result with
    | Ok ok -> Assert.Equal(expected, ok.Item2)
    | Error error -> Assert.Equal(error, ErrorCode.WrongArgFormatOperation)

    
let argsForParseValues =
    [|
        ("22.33", Operation.Plus, "33.7")
        ("rrr", Operation.Plus, "33")
    |]

[<Theory>]
[<InlineData(0)>]
[<InlineData(1)>]
let _parseValues i =
    let result = ParserWithErrorHandling.parseValues argsForParseValues.[i]
    match result with
    | Ok ok ->
        Assert.Equal(22.33m, ok.Item1)
        Assert.Equal(33.7m, ok.Item3)
    | Error error ->
        Assert.Equal(error, ErrorCode.WrongArgFormatValue)