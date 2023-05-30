using System;
using System.Net;

namespace ByteDev.Http
{
    public static class HttpStatusCodeExtensions
    {
        /// <summary>
        /// Returns a readable string for the HttpStatusCode.
        /// </summary>
        /// <param name="source">HttpStatusCode to perform the operation on.</param>
        /// <returns></returns>
        public static string ToReadableString(this HttpStatusCode source)
        {
            if (Enum.IsDefined(typeof(HttpStatusCode), source))
            {
                return $"{(int)source} {source}";
            }

            return source.ToString();
        }    
    }
}