using System;
using System.Collections.Generic;

namespace ByteDev.Http
{
    /// <summary>
    /// Represents a HTTP status code category.
    /// </summary>
    public class HttpStatusCodeCategory
    {
        private const int FirstHttpStatusCode = 100;

        private static readonly IDictionary<int, HttpStatusCodeCategory> Categories = new Dictionary<int, HttpStatusCodeCategory>
        {
            { 1, new HttpStatusCodeCategory { Code = 1, Name = "Informational", Description = "Request was received, continuing process." } },
            { 2, new HttpStatusCodeCategory { Code = 2, Name = "Success", Description = "Request was successfully received, understood, and accepted." } },
            { 3, new HttpStatusCodeCategory { Code = 3, Name = "Redirection", Description = "Further action needs to be taken in order to complete the request." } },
            { 4, new HttpStatusCodeCategory { Code = 4, Name = "Client Error", Description = "Request contains bad syntax or cannot be fulfilled." } },
            { 5, new HttpStatusCodeCategory { Code = 5, Name = "Server Error", Description = "Server failed to fulfil an apparently valid request." } }
        };

        /// <summary>
        /// Category code number (1-5).
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// Category name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Description of the category.
        /// </summary>
        public string Description { get; private set; }

        private HttpStatusCodeCategory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.HttpStatusCodeCategory" /> class based
        /// on it's code.
        /// </summary>
        /// <param name="categoryCode">Category code.</param>
        /// <returns>New instance of <see cref="T:ByteDev.Http.HttpStatusCodeCategory" />.</returns>
        /// <exception cref="T:System.ArgumentException">No HTTP status code category exists with <paramref name="categoryCode" />.</exception>
        public static HttpStatusCodeCategory CreateFromCode(int categoryCode)
        {
            try
            {
                return Categories[categoryCode];
            }
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException($"No HTTP status code category exists with code: '{categoryCode}'.", nameof(categoryCode), ex);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.HttpStatusCodeCategory" /> class based
        /// on a HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code.</param>
        /// <returns>New instance of <see cref="T:ByteDev.Http.HttpStatusCodeCategory" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="httpStatusCode" /> is not valid.</exception>
        /// <exception cref="T:System.ArgumentException">No HTTP status code category exists for <paramref name="httpStatusCode" />.</exception>
        public static HttpStatusCodeCategory CreateFromHttpStatusCode(int httpStatusCode)
        {
            if(httpStatusCode < FirstHttpStatusCode)
                throw new ArgumentOutOfRangeException(nameof(httpStatusCode), "HTTP status code is not valid.");

            try
            {
                var categoryCode = GetFirstDigit(httpStatusCode);

                return CreateFromCode(categoryCode);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"No HTTP status code category exists for: '{httpStatusCode}'.", nameof(httpStatusCode), ex);
            }
        }

        public override string ToString()
        {
            return $"{Code}xx {Name}";
        }

        private static int GetFirstDigit(int httpStatusCode)
        {
            return int.Parse(httpStatusCode.ToString().Substring(0, 1));
        }
    }
}
