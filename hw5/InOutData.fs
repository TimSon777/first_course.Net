module hw5.InOutData

[<CLIMutable>]
type InputExpression = {
    V1:decimal
    Operation:string 
    V2:decimal
}

[<CLIMutable>]
type OutputExpression = {
    V1:decimal
    Operation:Operation 
    V2:decimal
}