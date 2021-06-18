namespace ByteDev.Http
{
    internal static class HttpStatusCodeValidator
    {
        private const int FirstHttpStatusCode = 100;
        private const int LastHttpStatusCode = 599;

        public static bool Validate(int httpStatusCode)
        {
            return httpStatusCode >= FirstHttpStatusCode && httpStatusCode <= LastHttpStatusCode;
        }
    }
}