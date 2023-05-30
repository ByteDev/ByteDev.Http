using System;
using System.Net.Http.Headers;
using System.Reflection;

namespace ByteDev.Http
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Net.Http.Headers.HttpRequestHeaders" />.
    /// </summary>
    public static class HttpRequestHeadersExtensions
    {
        /// <summary>
        /// Add user agent header based on the provided assembly's name and version. Assembly's name
        /// will have all non-alphanumeric characters removed.
        /// </summary>
        /// <param name="source">Headers collection to perform the operation on.</param>
        /// <param name="assembly">Assembly to base user agent details on.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="assembly" /> is null.</exception>
        public static void AddUserAgent(this HttpRequestHeaders source, Assembly assembly)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            var assemblyName = assembly.GetName();

            var productName = assemblyName.Name.RemoveNonAlphaNumeric();
            var productVersion = $"{assemblyName.Version.Major}.{assemblyName.Version.Minor}.{assemblyName.Version.Build}";
            
            source.AddUserAgent(productName, productVersion);
        }

        /// <summary>
        /// Add user agent header.
        /// </summary>
        /// <param name="source">Headers collection to perform the operation on.</param>
        /// <param name="productName">Product name.</param>
        /// <param name="productVersion">Produce version.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddUserAgent(this HttpRequestHeaders source, string productName, string productVersion)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.UserAgent.Add(new ProductInfoHeaderValue(productName, productVersion));
        }

        /// <summary>
        /// Add a name value pair to the headers. If the name already exists then the
        /// value will be updated.
        /// </summary>
        /// <param name="source">Request headers collection to perform the operation on.</param>
        /// <param name="name">The header to add or update in the collection.</param>
        /// <param name="value">The content of the header.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddOrUpdate(this HttpRequestHeaders source, string name, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Contains(name))
                source.Remove(name);

            source.Add(name, value);
        }

        /// <summary>
        /// Add the accept JSON request header.
        /// </summary>
        /// <param name="source">Request headers collection to perform the operation on.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddAcceptJson(this HttpRequestHeaders source)
        {
            AddAccept(source, MediaTypes.Application.Json);
        }

        /// <summary>
        /// Add the accept XML request header.
        /// </summary>
        /// <param name="source">Request headers collection to perform the operation on.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddAcceptXml(this HttpRequestHeaders source)
        {
            AddAccept(source, MediaTypes.Application.Xml);
        }

        private static void AddAccept(HttpRequestHeaders source, string mediaType)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
        }
    }
}