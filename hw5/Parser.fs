module hw5.Parser
open InOutData

let parseInputData (expression:InputExpression) =
    match expression.Operation with
    | "plus" -> Ok { V1 = expression.V1; Operation = Operation.Plus; V2 = expression.V2 }
    | "minus" -> Ok { V1 = expression.V1; Operation = Operation.Minus; V2 = expression.V2 }
    | "divide" -> Ok { V1 = expression.V1; Operation = Operation.Divide; V2 = expression.V2 }
    | "multiply" -> Ok { V1 = expression.V1; Operation = Operation.Multiply; V2 = expression.V2 }
    | _ -> Error "Not a valid operation. Expected: plus, minus, multiply, divide"
  

