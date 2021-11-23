using hw8.Models;
using hw8.Services.CalculatorLogic;
using hw8.Services.CalculatorLogic.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculate() => View();
        
        [HttpPost]
        public IActionResult Calculate([FromServices] IExpressionCalculator calculator, string expression)
        {
            var isValid = calculator.TryParseStringIntoExpression(expression, out var exp);
            
            if (!isValid)
            {
                var modelError = new CalculatorModel("Wrong parameters");
                return View(modelError);
            }

            var result = new CalculatorVisitor().Visit(exp);
            var model = new CalculatorModel(result.ToString());

            return View(model);
        }
    }
}