using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw9.Infrastructure.Calculator
{
    public interface IExpressionCalculator
    {
        bool TryCalculate(string str, out string result);
    }
}