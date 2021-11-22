using System;
using System.Linq.Expressions;

namespace hw8.Services.CalculatorLogic
{
    public interface IExpressionCalculator
    {
        Expression<Func<string>> ParseStringIntoExpression(string str);
        public Func<string> GetFuncByExpression(string str) => ParseStringIntoExpression(str).Compile();
    }
}