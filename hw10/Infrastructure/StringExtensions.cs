using System.Collections.Generic;
using System.Globalization;

namespace hw10.Infrastructure
{
    public static class StringExtensions
    {
        public static void SplitMathExpressionByOperationsAndNumbers(this string str, List<string> elements)
        {
            var strWithoutSpaces = str.Replace(" ", "")
                .ToLower()
                .Replace("plus", "+")
                .Replace("minus", "-")
                .Replace("multiplication", "*")
                .Replace("division", "/");

            var startCurrentNumber = -1;
            for (var i = 0; i < strWithoutSpaces.Length; i++)
            {
                if (char.IsLetter(strWithoutSpaces[i])) return;
                if (char.IsDigit(strWithoutSpaces[i]) || strWithoutSpaces[i] == '.')
                {
                    if (startCurrentNumber == -1) startCurrentNumber = i;
                    continue;
                }

                if (startCurrentNumber != -1)
                {
                    AddNumberToList(elements, strWithoutSpaces[startCurrentNumber..i]);
                }
                
                elements.Add(strWithoutSpaces[i].ToString());
                startCurrentNumber = -1;
            }

            if (startCurrentNumber == -1) return;

            AddNumberToList(elements, strWithoutSpaces[startCurrentNumber..]);
        }

        private static void AddNumberToList(ICollection<string> elements, string str)
        {
            var number = double.Parse(str,NumberStyles.Any, CultureInfo.InvariantCulture);
            elements.Add(number.ToString(CultureInfo.InvariantCulture));
        }
    }
}