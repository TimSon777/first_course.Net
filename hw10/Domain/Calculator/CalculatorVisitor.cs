using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using hw10.Services.Calculator;

namespace hw10.Domain.Calculator
{
    public class CalculatorVisitor : IExpressionVisitor
    {
        public virtual async Task<Expression> VisitAsync(Expression exp)
            => await VisitAsync((dynamic) exp);
        
        public virtual async Task<Expression> VisitAsync(BinaryExpression exp)
        {
            var leftTask  = VisitAsync(exp.Left);
            var rightTask = VisitAsync(exp.Right);

            await Task.WhenAll(leftTask, rightTask);
            
            var leftResult  = ((ConstantExpression) await leftTask).Value as double?;
            var rightResult = ((ConstantExpression) await rightTask).Value as double?;
            
            var res = exp.NodeType switch
            {
                ExpressionType.Add        => leftResult + rightResult,
                ExpressionType.Subtract   => leftResult - rightResult,
                ExpressionType.Multiply   => leftResult * rightResult,
                ExpressionType.Divide     => leftResult / rightResult,
                _                         => throw new NotImplementedException()
            };

            return Expression.Constant(res, typeof(double));
        }

        public virtual async Task<Expression> VisitAsync(ConstantExpression node)
            => await Task.FromResult(node);
    }
}