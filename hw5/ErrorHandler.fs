module hw5.ErrorHandler
open Parser
    
let errorExpressionHandler expression =
    match expression with
    | Ok e -> parseInputData e
    | Error e ->  Error e   
