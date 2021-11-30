using System;
using System.Collections.Generic;
using System.Net;

namespace ByteDev.Http
{
    /// <summary>
    /// Represents a HTTP status code category.
    /// </summary>
    public class HttpStatusCodeCategory
    {
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

        /// <summary>
        /// Indicates if category is informational.
        /// </summary>
        public bool IsInformational => Code == 1;

        /// <summary>
        /// Indicates if category is success.
        /// </summary>
        public bool IsSuccess => Code == 2;

        /// <summary>
        /// Indicates if category is redirection.
        /// </summary>
        public bool IsRedirection => Code == 3;

        /// <summary>
        /// Indicates if category is client error.
        /// </summary>
        public bool IsClientError => Code == 4;

        /// <summary>
        /// Indicates if category is server error.
        /// </summary>
        public bool IsServerError => Code == 5;

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
        public static HttpStatusCodeCategory CreateFromCategoryCode(int categoryCode)
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
        public static HttpStatusCodeCategory CreateFromHttpStatusCode(int httpStatusCode)
        {
            if (!HttpStatusCodeValidator.Validate(httpStatusCode))
                throw new ArgumentOutOfRangeException(nameof(httpStatusCode), $"HTTP status code: '{httpStatusCode}' is not valid.");

            var categoryCode = GetFirstDigit(httpStatusCode);

            return CreateFromCategoryCode(categoryCode);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.HttpStatusCodeCategory" /> class based
        /// on a HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code.</param>
        /// <returns>New instance of <see cref="T:ByteDev.Http.HttpStatusCodeCategory" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="httpStatusCode" /> is not valid.</exception>
        public static HttpStatusCodeCategory CreateFromHttpStatusCode(HttpStatusCode httpStatusCode)
        {
            return CreateFromHttpStatusCode((int)httpStatusCode);
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
