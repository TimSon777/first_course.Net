using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace hw9.Infrastructure.Calculator
{
    public class ExpressionCalculator : IExpressionCalculator
    {
        public bool TryCalculate(string str, out string result)
        {
            result = "";
            
            var output = new Stack<Expression>();
            var operations = new Stack<Operation>();
            var elements = new List<string>();
            
            var isValid = str.TrySplitMathExpressionByOperationsAndNumbers(elements);
            if (!isValid) return false;
            
            try
            {
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

                var expression = new CalculatorVisitor().Visit(output.Pop());
                result = expression.ToString();
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        private static void HighlightExpressionInBracketsInExpression(Stack<Operation> operations, Stack<Expression> output)
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