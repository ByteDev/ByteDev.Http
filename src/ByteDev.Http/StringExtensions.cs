using System.Linq;

namespace ByteDev.Http
{
    internal static class StringExtensions
    {
        public static int CountOccurrences(this string source, char c)
        {
            if (string.IsNullOrEmpty(source))
                return 0;

            return source.Count(mt => mt == c);
        }
    }
}