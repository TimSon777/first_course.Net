using System;
using System.Linq.Expressions;

namespace hw8.Services.CalculatorLogic
{
    public class ExpressionCalculator : IExpressionCalculator
    {
        public Expression<Func<string>> ParseStringIntoExpression(string str)
        {
            Expression<Func<string>> e = () => "777";
            return e;
        }
    }
}