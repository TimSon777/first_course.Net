using System.Linq.Expressions;

namespace hw8.Services.CalculatorLogic
{
    public interface IExpressionCalculator
    {
        bool TryParseStringIntoExpression(string str, out Expression expression);
    }
}