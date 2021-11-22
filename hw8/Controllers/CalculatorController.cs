using hw8.Models;
using hw8.Services.CalculatorLogic;
using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate([FromServices] IExpressionCalculator calculator, string expression)
        {
            var f = calculator.GetFuncByExpression(expression);
            
            var model = new CalculatorModel
            {
                Answer = f()
            };
            
            return View(model);
        }
    }
}