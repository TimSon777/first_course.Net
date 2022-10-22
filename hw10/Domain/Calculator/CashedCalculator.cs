using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace hw10.Domain.Calculator
{
    public class CashedCalculator : ICashedCalculator
    {
        private readonly IExpressionCalculator _expressionCalculator;

        private readonly ConcurrentDictionary<string, double> _cache = new();
        
        public CashedCalculator(
            IExpressionCalculator expressionCalculator)
        {
            _expressionCalculator = expressionCalculator;
        }
        
        public async Task<double> Calculate(string str)
        {
            str = str.Replace(" ", "");
            var calculation = _cache.GetOrAdd(str, await _expressionCalculator.Calculate(str));
            return calculation;
        }
    }
}