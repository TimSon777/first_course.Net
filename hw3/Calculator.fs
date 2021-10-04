module hw3.Calculator
let calculate x operation y =
    let xd = x |> double
    let yd = y |> double
    
    match operation with
    | CalculatorOperation.Plus -> xd + yd
    | CalculatorOperation.Minus -> xd - yd
    | CalculatorOperation.Divide -> xd / yd
    | _ -> xd  * yd