using System;
using System.Net.Http.Headers;

namespace ByteDev.Http
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Net.Http.Headers.HttpContentHeaders" />.
    /// </summary>
    public static class HttpContentHeadersExtensions
    {
        /// <summary>
        /// Add a name value pair to the headers. If the name already exists then the
        /// value will be updated.
        /// </summary>
        /// <param name="source">Headers collection to perform the operation on.</param>
        /// <param name="name">The header to add or update in the collection.</param>
        /// <param name="value">The content of the header.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddOrUpdate(this HttpContentHeaders source, string name, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Contains(name))
                source.Remove(name);

            source.Add(name, value);
        }
    }
}