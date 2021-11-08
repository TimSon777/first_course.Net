using hw7.Controllers.Calculator;
using Xunit;

namespace Tests7
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("5", "plus", "5", "10")]
        [InlineData("5", "minus", "3", "2")]
        [InlineData("5", "division", "5", "1")]
        [InlineData("5", "multiplication", "5", "25")]
        public void Calculate_ValidArguments_Correct(string firstValue, string operation, string secondValue, string excepted)
        {
            MakeGeneralPartTests(firstValue, operation, secondValue, excepted);
        }
        
        [Theory]
        [InlineData("error", "plus", "5", "Ожидалось число")]
        [InlineData("5", "minus", "error", "Ожидалось число")]
        [InlineData("5", "error", "5", "Ожидалось: plus, minus, multiplication или division")]
        [InlineData("5", "division", "0", "Infinity")]
        [InlineData("0", "division", "0", "Результат не определен")]
        public void Calculate_InvalidArguments_Wrong(string firstValue, string operation, string secondValue, string excepted)
        {
            MakeGeneralPartTests(firstValue, operation, secondValue, excepted);
        }
        
        private static void MakeGeneralPartTests(string firstValue, string operation, string secondValue, string excepted)
        {
            var result = new CalculatorController()
                .Calculate(new Calculator(), firstValue, operation, secondValue);
            Assert.Equal(excepted, result);
        }
    }
}