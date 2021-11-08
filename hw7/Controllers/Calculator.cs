<<<<<<< HEAD
﻿using System.Globalization;
using hw7.Interfaces;

namespace hw7.Controllers.Calculator
{
    public class Calculator : ICalculator
    {
        public string Add(double firstValue, double secondValue)
            => (firstValue + secondValue).ToString(CultureInfo.InvariantCulture);
        
        public string Subtract(double firstValue, double secondValue)
            => (firstValue - secondValue).ToString(CultureInfo.InvariantCulture);
        
        public string Multiply(double firstValue, double secondValue)
            => (firstValue * secondValue).ToString(CultureInfo.InvariantCulture);
        
        public string Divide(double firstValue, double secondValue)
        {
            if (firstValue == 0 && secondValue == 0) return "Результат не определен";
            if (secondValue == 0) return "Infinity";
            
            return (firstValue / secondValue).ToString(CultureInfo.InvariantCulture);
        }
    }
=======
﻿using System.Globalization;
using hw7.Interfaces;

namespace hw7.Controllers.Calculator
{
    public class Calculator : ICalculator
    {
        public string Add(double firstValue, double secondValue)
            => (firstValue + secondValue).ToString(CultureInfo.InvariantCulture);
        
        public string Subtract(double firstValue, double secondValue)
            => (firstValue - secondValue).ToString(CultureInfo.InvariantCulture);
        
        public string Multiply(double firstValue, double secondValue)
            => (firstValue * secondValue).ToString(CultureInfo.InvariantCulture);
        
        public string Divide(double firstValue, double secondValue)
        {
            if (firstValue == 0 && secondValue == 0) return "Результат не определен";
            if (secondValue == 0) return "Infinity";
            
            return (firstValue / secondValue).ToString(CultureInfo.InvariantCulture);
        }
    }
>>>>>>> origin/2k-420
}