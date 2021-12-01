using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace hw9.Infrastructure.Calculator
{
    public class CalculatorVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            Thread.Sleep(1000);

            var left = Task.Run(() => Visit(node.Left));
            var right = Task.Run(() => Visit(node.Right));
            
            Task.WhenAll(left, right);
        
            var leftResult = ((ConstantExpression) left.Result)?.Value as double?;
            var rightResult = ((ConstantExpression) right.Result)?.Value as double?;
            
            var res = node.NodeType switch
            {
                ExpressionType.Add        => leftResult + rightResult,
                ExpressionType.Subtract   => leftResult - rightResult,
                ExpressionType.Multiply   => leftResult * rightResult,
                ExpressionType.Divide     => leftResult / rightResult,
                _                         => throw new NotImplementedException()
            };

            return Expression.Constant(res, typeof(double));
        }
    }
}