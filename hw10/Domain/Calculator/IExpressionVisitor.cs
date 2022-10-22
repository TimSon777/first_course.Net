using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw10.Services.Calculator
{
    public interface IExpressionVisitor
    {
        Task<Expression> VisitAsync(Expression exp);
        Task<Expression> VisitAsync(BinaryExpression exp);
        Task<Expression> VisitAsync(ConstantExpression exp);
    }
}