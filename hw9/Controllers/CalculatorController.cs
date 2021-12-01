using System.Globalization;
using hw9.Infrastructure;
using hw9.Infrastructure.Calculator;
using hw9.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw9.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICashedCalculator _calculator;

        public CalculatorController(ICashedCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        private const string ErrorNotValidBrackets = "Wrong brackets";
        private const string ErrorNotValidExpression = "Wrong parameters";

        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            if (!expression.IsValidPlacementBrackets())
                return View(new CalculatorModel(ErrorNotValidBrackets));

            var isValid = _calculator.TryCalculate(expression, out var result);
            if (!isValid) return View(new CalculatorModel(ErrorNotValidExpression));
            return View(new CalculatorModel(result.ToString(CultureInfo.InvariantCulture)));
        }
    }
}