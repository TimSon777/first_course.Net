module Tests.ProgramTests
open Xunit
open hw3

[<Fact>]
let ``Main_WrongInputData_WillReturnNotZero`` () =
    let args = [|"1";"+";"&&&"|]
    let check = Program.main args
    Assert.True(check <> 0)

[<Fact>]
let ``Main_CorrectInputData_WillReturnZero`` () =
    let args = [|"1";"+";"3"|]
    let check = Program.main args
    let result = check = 0
    Assert.True(result)     