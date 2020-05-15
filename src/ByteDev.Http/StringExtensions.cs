namespace ByteDev.Http
{
    internal static class StringExtensions
    {
        public static int SafeLength(this string source)
        {
            if (source == null)
                return 0;

            return source.Length;
        }
    }
}