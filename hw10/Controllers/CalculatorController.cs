using System;
using System.Globalization;
using System.Threading.Tasks;
using hw10.Domain.Calculator;
using hw10.Models;
using hw10.Services.Logging;
using Microsoft.AspNetCore.Mvc;

namespace hw10.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICashedCalculator _calculator;
        private readonly IExceptionHandler _exceptionHandler;

        public CalculatorController(ICashedCalculator calculator, IExceptionHandler exceptionHandler)
        {
            _calculator = calculator;
            _exceptionHandler = exceptionHandler;
        }
        
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(string expression)
        {
            try
            {
                var result = await _calculator.Calculate(expression);
                return View(new CalculatorModel(result.ToString(CultureInfo.InvariantCulture)));
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
                return View(new CalculatorModel("Error"));
            }
        }
    }
}