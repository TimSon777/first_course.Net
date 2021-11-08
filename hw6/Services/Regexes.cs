using System.Text.RegularExpressions;

namespace hw6.Services
{
    public static class Regexes
    {
        public static readonly Regex RegexCamelCase = new(@"([A-Z]+(?![a-z])|[A-Z][a-z]+|[0-9]+|[a-z]+)");
    }
}