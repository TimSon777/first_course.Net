module hw3.Parser

open System

let checkArgLength (array: string[]) =
    array.Length = 3

let tryParseOperation (arg: string) (operation: outref<CalculatorOperation>) =
    operation <- match arg with
    | "+" -> CalculatorOperation.Plus
    | "-" -> CalculatorOperation.Minus
    | "/" -> CalculatorOperation.Divide
    | _ -> CalculatorOperation.Multiply
    operation <> CalculatorOperation.Multiply || arg = "*"
    
let parseCalcArguments (args: string[]) (val1: outref<int>) (operation: outref<CalculatorOperation>) (val2: outref<int>) =
    if Int32.TryParse(args.[0], &val1) = false || Int32.TryParse(args.[2], &val2) = false then  
        ErrorCode.WrongArgFormatInt
    elif checkArgLength args = false then
        ErrorCode.WrongArgLength
    elif tryParseOperation args.[1] &operation = false then
        ErrorCode.WrongArgFormatOperation
    else
        ErrorCode.Correct