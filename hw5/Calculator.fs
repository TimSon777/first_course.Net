module hw5.Calculator
open InOutData

let calculate expression =
    match expression.Operation with
    | Operation.Plus -> expression.V1 + expression.V2
    | Operation.Minus -> expression.V1 - expression.V2
    | Operation.Divide -> expression.V1 / expression.V2
    | _ -> expression.V1 * expression.V2

