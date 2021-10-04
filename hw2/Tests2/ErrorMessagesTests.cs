using hw2_il;
using Xunit;

namespace Tests
{
    public class ErrorMessagesTests
    {
        [Fact]
        public void IsErrorCodeDisplayErrorMessage_WrongInput_WillReturnFalse()
        {
            var args = new[] { "1", "+", "2" };
            var result = ErrorMessages.IsErrorCodeDisplayErrorMessage(ErrorCode.Correct, args);
            Assert.False(result);
        }
        
        [Theory]
        [InlineData(1, "1", "+", "1", "")]
        [InlineData(2, "1", "+", "s")]
        [InlineData(3, "1", "fd", "1")]
        public void IsErrorCodeDisplayErrorMessage_WrongInput_WillReturnTrue(int code, params string[] args)
        {
            var result = ErrorMessages.IsErrorCodeDisplayErrorMessage((ErrorCode) code, args);
            Assert.True(result);
        }
    }
}