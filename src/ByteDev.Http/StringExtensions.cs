using System.Linq;
using System.Text.RegularExpressions;

namespace ByteDev.Http
{
    internal static class StringExtensions
    {
        public static int CountOccurrences(this string source, char ch)
        {
            if (string.IsNullOrEmpty(source))
                return 0;

            return source.Count(mt => mt == ch);
        }

        public static string RemoveNonAlphaNumeric(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            return new Regex("[^A-Za-z0-9]").Replace(source, string.Empty);
        }
    }
}