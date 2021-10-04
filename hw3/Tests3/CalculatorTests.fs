module Tests.CalculatorTests

open Xunit
open hw3
    
[<Theory>]
[<InlineData(5, 7, 12)>]
[<InlineData(-5, 7, 2)>]
[<InlineData(-5, -7, -12)>]
[<InlineData(5, -7, -2)>]
let ``Calculate_Plus_WillReturnCorrectResult`` (val1, val2, expected) =
    let result = Calculator.calculate val1 CalculatorOperation.Plus val2
    Assert.Equal(result, expected)
    
[<Theory>]
[<InlineData(5, 7, -2)>]
[<InlineData(-5, 7, -12)>]
[<InlineData(-5, -7, 2)>]
[<InlineData(5, -7, 12)>]
let ``Calculate_Minus_WillReturnCorrectResult`` (val1, val2, expected) = 
    let result = Calculator.calculate val1 CalculatorOperation.Minus val2
    Assert.Equal(result, expected)
    
[<Theory>]
[<InlineData(5, 7, 35)>]
[<InlineData(-5, 7, -35)>]
[<InlineData(-5, -7, 35)>]
[<InlineData(5, -7, -35)>]
let ``Calculate_Multiply_WillReturnCorrectResult`` (val1, val2, expected) = 
    let result = Calculator.calculate val1 CalculatorOperation.Multiply val2
    Assert.Equal(result, expected)

[<Theory>]
[<InlineData(10, 5, 2)>]
[<InlineData(-10, 5, -2)>]
[<InlineData(-10, -5, 2)>]
[<InlineData(10, -5, -2)>]
[<InlineData(7, 2, 3.5)>]
let ``Calculate_Divide_WillReturnCorrectResult`` (val1,  val2, expected) = 
    let result = Calculator.calculate val1 CalculatorOperation.Divide val2
    Assert.Equal(result, expected)
