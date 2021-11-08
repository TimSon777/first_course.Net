using System;
using hw7.Enums;
using hw7.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hw7.Controllers.Calculator
{
    public class CalculatorController : Controller
    {
        public string Calculate([FromServices]ICalculator calculator,
            string firstValue,
            string operation,
            string secondValue)
        {
            var isDouble1 = double.TryParse(firstValue, out var v1);
            var isDouble2 = double.TryParse(secondValue, out var v2);
            if (!isDouble1 || !isDouble2) return "Ожидалось число";

            var isOperation = TryParseEnum<CalculatorOperation>(operation, out var op);
            if (!isOperation) return "Ожидалось: plus, minus, multiplication или division";
            
            return op switch
            {
                CalculatorOperation.Plus => calculator.Add(v1, v2),
                CalculatorOperation.Minus => calculator.Subtract(v1, v2),
                CalculatorOperation.Multiplication => calculator.Multiply(v1, v2),
                _ => calculator.Divide(v1, v2),
            };
        }

        private static bool TryParseEnum<T>(string str, out T result) 
            where T : struct
        {
            var correctView = char.ToUpper(str[0]) + str[1..str.Length].ToLower();
            var isOperation = Enum.TryParse(correctView, out result);
            return isOperation;
        }
    }
}