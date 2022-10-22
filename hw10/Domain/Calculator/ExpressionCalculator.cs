using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using hw10.Infrastructure;
using hw10.Services.Calculator;

namespace hw10.Domain.Calculator
{
    public class ExpressionCalculator : IExpressionCalculator
    {
        private readonly IExpressionVisitor _visitor;

        public ExpressionCalculator(IExpressionVisitor visitor) => _visitor = visitor;

        public async Task<double> Calculate(string str)
        {
            var output = new Stack<Expression>();
            var operations = new Stack<Operation>();
            var elements = new List<string>();
            
            str.SplitMathExpressionByOperationsAndNumbers(elements);
            
            foreach (var e in elements)
            {
                if (double.TryParse(e, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
                {
                    output.Push(Expression.Constant(number, typeof(double)));
                }
                else if (OperationExtensions.TryParse(e, out var operation))
                {
                    if (operation == Operation.RightBracket)
                        HighlightExpressionInBracketsInExpression(operations, output);

                    while (operations.Count != 0 
                           && OperationExtensions.Priorities[operations.Peek()] >= OperationExtensions.Priorities[operation] 
                           && operation != Operation.LeftBracket)
                    {
                        var exp = operations.Pop().ToBinaryExpression(output);
                        output.Push(exp);
                    }
                    
                    if (operation != Operation.RightBracket) operations.Push(operation);
                }
            }

            foreach (var exp in operations
                .Select(operation => operation.ToBinaryExpression(output)))
            {
                output.Push(exp);
            }

            var result = await _visitor.VisitAsync(output.Pop());
            if (((ConstantExpression) result).Value is double res) return res;
            return 0;
        }

        private static void HighlightExpressionInBracketsInExpression(
            Stack<Operation> operations, 
            Stack<Expression> output)
        {
            var currentOperation = operations.Pop();
            while (currentOperation != Operation.LeftBracket)
            {
                var expression = currentOperation.ToBinaryExpression(output);
                output.Push(expression);
                currentOperation = operations.Pop();
            }
        }
    }
}