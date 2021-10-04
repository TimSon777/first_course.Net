module Tests.ErrorMessagesTests
open Xunit
open hw3

[<Fact>]
let ``IsErrorCodeDisplayErrorMessage_WrongInput_WillReturnFalse`` () =
    let args = [|"1";"+";"2"|]
    let result = ErrorMessages.isErrorCodeDisplayErrorMessage ErrorCode.Correct args
    Assert.False(result)
        
[<Theory>]
[<InlineData(ErrorCode.WrongArgLength, "1", "+", "1", true)>]
[<InlineData(ErrorCode.WrongArgFormatInt, "1", "+", "s", false)>]
[<InlineData(ErrorCode.WrongArgFormatOperation, "1", "fd", "1", false)>]
let ``IsErrorCodeDisplayErrorMessage_WrongInput_WillReturnTrue`` (code, arg1, arg2, arg3, isFourArgs) =
    if isFourArgs then
        let result = ErrorMessages.isErrorCodeDisplayErrorMessage code [|arg1;arg2;arg3;""|]
        Assert.True(result)
    else
        let result = ErrorMessages.isErrorCodeDisplayErrorMessage code [|arg1;arg2;arg3|]
        Assert.True(result);