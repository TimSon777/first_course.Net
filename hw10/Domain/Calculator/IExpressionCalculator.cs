using System.Threading.Tasks;

namespace hw10.Domain.Calculator
{
    public interface IExpressionCalculator
    {
        Task<double> Calculate(string str);
    }
}