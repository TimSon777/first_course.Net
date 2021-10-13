module hw4.Calculator

let calculate (x:decimal, operation, y) =
    match operation with
    | Operation.Plus -> x + y
    | Operation.Minus -> x - y
    | Operation.Divide -> x / y
    | _ -> x * y

    
    