using MQL4LogParser.Enums;

namespace MQL4LogParser.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string str, Operation operation)
        {
            return str.Contains($"{operation}", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
