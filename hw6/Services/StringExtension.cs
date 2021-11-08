using System.Collections.Generic;
using System.Linq;

namespace hw6.Services
{
    public static class StringExtension
    {
        public static IEnumerable<string> SplitByCamelCase(this string str)
            => Regexes.RegexCamelCase
                .Matches(str)
                .Select(a => a.Value);
    }
}