using System;
using System.Net.Http;

namespace ByteDev.Http
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Net.Http.HttpContent" />.
    /// </summary>
    public static class HttpContentExtensions
    {
        /// <summary>
        /// Determines if the content is type JSON.
        /// </summary>
        /// <param name="source">Content to perform the operation on.</param>
        /// <returns>True the content is JSON; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsJson(this HttpContent source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Headers?.ContentType?.MediaType == MediaTypes.Application.Json;
        }

        /// <summary>
        /// Determines if the content is type XML.
        /// </summary>
        /// <param name="source">Content to perform the operation on.</param>
        /// <returns>True the content is XML; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsXml(this HttpContent source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Headers?.ContentType?.MediaType == MediaTypes.Application.Xml;
        }

        /// <summary>
        /// Determines if the content is type form URL encoded.
        /// </summary>
        /// <param name="source">Content to perform the operation on.</param>
        /// <returns>True the content is form URL encoded; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsFormUrlEncoded(this HttpContent source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Headers?.ContentType?.MediaType == MediaTypes.Application.FormUrlEncoded;
        }
    }
}