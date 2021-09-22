using System;
using hw2_il;

namespace hw2
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var check = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            var isError = ErrorMessages.IsErrorCodeDisplayErrorMessage(check, args);
            if (isError) return (int) check;
            
            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"Result is: {result}");
            return (int) ErrorCode.Correct;
        }
    }
}