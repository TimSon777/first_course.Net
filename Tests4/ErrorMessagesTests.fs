module Tests.ErrorMessagesTests
open Xunit
open hw4
        
[<Theory>]
[<InlineData(ErrorCode.WrongArgLength, "1", "+", "1", true)>]
[<InlineData(ErrorCode.WrongArgFormatValue, "1", "+", "s", false)>]
[<InlineData(ErrorCode.WrongArgFormatOperation, "1", "fd", "1", false)>]
let IsErrorCodeDisplayErrorMessage_WrongInput_WillReturnTrue code arg1 arg2 arg3 isFourArgs =
    if isFourArgs then
        let result = ErrorMessages.getErrorMessage code [|arg1;arg2;arg3;""|]
        Assert.True(result.Length <> 0)
    else
        let result = ErrorMessages.getErrorMessage code [|arg1;arg2;arg3|]
        Assert.True(result.Length<> 0);