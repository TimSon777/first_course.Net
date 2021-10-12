module Tests.ParserTests

open Xunit
open hw3
open hw3
    
[<Theory>]
[<InlineData("+", CalculatorOperation.Plus)>]
[<InlineData("-", CalculatorOperation.Minus)>]
[<InlineData("*", CalculatorOperation.Multiply)>]
[<InlineData("/", CalculatorOperation.Divide)>]
let ``ParseCalcArguments_Operation_WillParse`` (operation, operationExpected) =
    let args = [|"4";operation;"777"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = CalculatorOperation.Plus
    let check = Parser.parseCalcArguments args &val1 &operationResult &val2
    Assert.Equal(ErrorCode.Correct, check)
    Assert.Equal(4, val1)
    Assert.Equal(operationExpected, operationResult)
    Assert.Equal(777, val2)

[<Fact>]
let ``ParseCalcArguments_NotNumber_WillReturnWrongArgFormatInt`` () =
    let args = [|"4";"+";"turn around"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = CalculatorOperation.Plus
    let check = Parser.parseCalcArguments args &val1 &operationResult &val2
    Assert.Equal(ErrorCode.WrongArgFormatInt, check)

[<Fact>]
let ``ParseCalcArguments_NotOperation_WillReturnWrongArgFormatOperation`` () =
    let args = [|"4";"turn around";"1337"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = CalculatorOperation.Plus
    let check = Parser.parseCalcArguments args &val1 &operationResult &val2
    Assert.Equal(ErrorCode.WrongArgFormatOperation, check)

[<Fact>]
let ``ParseCalcArguments_WrongLengthArgs_WillReturnWrongArgLength`` () =
    let args = [|"4";"+";"1337";"Timur"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = CalculatorOperation.Plus
    let check = Parser.parseCalcArguments args &val1 &operationResult &val2
    Assert.Equal(ErrorCode.WrongArgLength, check)
     
