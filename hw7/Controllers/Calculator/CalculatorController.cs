using System;
using hw7.Enums;
using hw7.Interfaces;
using hw7.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw7.Controllers.Calculator
{
    public class CalculatorController : Controller
    {
        public IActionResult Calculate([FromServices] ICalculator calculator,
            string firstValue,
            string operation,
            string secondValue)
        {
            var isDouble1 = double.TryParse(firstValue, out var v1);
            var isDouble2 = double.TryParse(secondValue, out var v2);
            if (!isDouble1 || !isDouble2) return View(new Calculation("Ожидалось число"));

            var isOperation = TryParseEnum<CalculatorOperation>(operation, out var op);
            if (!isOperation) return View(new Calculation("Ожидалось: plus, minus, multiplication или division"));

            var res =  op switch
            {
                CalculatorOperation.Plus => calculator.Add(v1, v2),
                CalculatorOperation.Minus => calculator.Subtract(v1, v2),
                CalculatorOperation.Multiplication => calculator.Multiply(v1, v2),
                _ => calculator.Divide(v1, v2),
            };

            return View(new Calculation(res));
        }

        public static bool TryParseEnum<T>(string str, out T result)
            where T : struct
        {
            var correctView = char.ToUpper(str[0]) + str[1..str.Length].ToLower();
            var isOperation = Enum.TryParse(correctView, out result);
            return isOperation;
        }
    }
}