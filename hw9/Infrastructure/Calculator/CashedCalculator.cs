using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using hw9.Services.Database;
using hw9.Services.Database.Models;

namespace hw9.Infrastructure.Calculator
{
    public class CashedCalculator : ICashedCalculator
    {
        private readonly IExpressionCalculator _expressionCalculator;
        private readonly ApplicationDbContext _applicationDbContext;

        public CashedCalculator(IExpressionCalculator expressionCalculator, ApplicationDbContext applicationDbContext)
        {
            _expressionCalculator = expressionCalculator;
            _applicationDbContext = applicationDbContext;
        }


        public bool TryCalculate(string str, out string result)
        {
            str = str.Replace(" ", "");
            var calculation = _applicationDbContext.Calculations.FirstOrDefault(a => a.Expression == str);
            if (calculation is null)
            { 
                var isValid = _expressionCalculator.TryCalculate(str, out result);
                if (!isValid) return false;
                
                calculation = new Calculation
                {
                    Expression = str,
                    Result = result.ToString(CultureInfo.InvariantCulture)
                };

                _applicationDbContext.Calculations.Add(calculation);
                _applicationDbContext.SaveChanges();
                return true;
            }

            result = calculation.Result;
            return true;
        }
    }
}