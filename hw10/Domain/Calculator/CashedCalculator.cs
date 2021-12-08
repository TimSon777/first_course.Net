using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using hw10.Services.Database;
using hw10.Services.Database.Models;

namespace hw10.Domain.Calculator
{
    public class CashedCalculator : ICashedCalculator
    {
        private readonly IExpressionCalculator _expressionCalculator;
        private readonly ApplicationDbContext _applicationDbContext;

        public CashedCalculator(
            IExpressionCalculator expressionCalculator, 
            ApplicationDbContext applicationDbContext)
        {
            _expressionCalculator = expressionCalculator;
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<double> Calculate(string str)
        {
            str = str.Replace(" ", "");
            var calculation = _applicationDbContext.Calculations
                .FirstOrDefault(a => a.Expression == str);

            if (calculation is not null) return double.Parse(calculation.Result, CultureInfo.InvariantCulture);
            
            var result = await _expressionCalculator.Calculate(str);

            calculation = new Calculation
            {
                Expression = str,
                Result = result.ToString(CultureInfo.InvariantCulture)
            };

            await _applicationDbContext.Calculations.AddAsync(calculation);
            await _applicationDbContext.SaveChangesAsync();

            return result;
        }
    }
}