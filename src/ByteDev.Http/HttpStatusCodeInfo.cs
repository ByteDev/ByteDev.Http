using System;
using System.Collections.Generic;
using System.Net;

namespace ByteDev.Http
{
    /// <summary>
    /// Represents a standard HTTP status code with extended information.
    /// </summary>
    /// <remarks>
    /// Full list of codes can be viewed at Wikipedia:
    /// https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
    /// </remarks>
    public class HttpStatusCodeInfo
    {
        private static readonly IDictionary<int, HttpStatusCodeInfo> Statuses = new Dictionary<int, HttpStatusCodeInfo>
        {
            { 100, new HttpStatusCodeInfo { Code = 100, Name = "Continue" } },
            { 101, new HttpStatusCodeInfo { Code = 101, Name = "Switching Protocols" } },
            { 102, new HttpStatusCodeInfo { Code = 102, Name = "Processing" } },
            { 103, new HttpStatusCodeInfo { Code = 103, Name = "Early Hints" } },

            { 200, new HttpStatusCodeInfo { Code = 200, Name = "OK" } },
            { 201, new HttpStatusCodeInfo { Code = 201, Name = "Created" } },
            { 202, new HttpStatusCodeInfo { Code = 202, Name = "Accepted" } },
            { 203, new HttpStatusCodeInfo { Code = 203, Name = "Non-authoritative Information" } },
            { 204, new HttpStatusCodeInfo { Code = 204, Name = "No Content" } },
            { 205, new HttpStatusCodeInfo { Code = 205, Name = "Reset Content" } },
            { 206, new HttpStatusCodeInfo { Code = 206, Name = "Partial Content" } },
            { 207, new HttpStatusCodeInfo { Code = 207, Name = "Multi-Status" } },
            { 208, new HttpStatusCodeInfo { Code = 208, Name = "Already Reported" } },
            { 226, new HttpStatusCodeInfo { Code = 226, Name = "IM Used" } },

            { 300, new HttpStatusCodeInfo { Code = 300, Name = "Multiple Choices" } },
            { 301, new HttpStatusCodeInfo { Code = 301, Name = "Moved Permanently" } },
            { 302, new HttpStatusCodeInfo { Code = 302, Name = "Found" } },                 // used to be "Moved Temporarily"
            { 303, new HttpStatusCodeInfo { Code = 303, Name = "See Other" } },
            { 304, new HttpStatusCodeInfo { Code = 304, Name = "Not Modified" } },
            { 305, new HttpStatusCodeInfo { Code = 305, Name = "Use Proxy" } },
            { 306, new HttpStatusCodeInfo { Code = 306, Name = "Switch Proxy" } },
            { 307, new HttpStatusCodeInfo { Code = 307, Name = "Temporary Redirect" } },
            { 308, new HttpStatusCodeInfo { Code = 308, Name = "Permanent Redirect" } },

            { 400, new HttpStatusCodeInfo { Code = 400, Name = "Bad Request" } },
            { 401, new HttpStatusCodeInfo { Code = 401, Name = "Unauthorized" } },
            { 402, new HttpStatusCodeInfo { Code = 402, Name = "Payment Required" } },
            { 403, new HttpStatusCodeInfo { Code = 403, Name = "Forbidden" } },
            { 404, new HttpStatusCodeInfo { Code = 404, Name = "Not Found" } },
            { 405, new HttpStatusCodeInfo { Code = 405, Name = "Method Not Allowed" } },
            { 406, new HttpStatusCodeInfo { Code = 406, Name = "Not Acceptable" } },
            { 407, new HttpStatusCodeInfo { Code = 407, Name = "Proxy Authentication Required" } },
            { 408, new HttpStatusCodeInfo { Code = 408, Name = "Request Timeout" } },
            { 409, new HttpStatusCodeInfo { Code = 409, Name = "Conflict" } },
            { 410, new HttpStatusCodeInfo { Code = 410, Name = "Gone" } },
            { 411, new HttpStatusCodeInfo { Code = 411, Name = "Length Required" } },
            { 412, new HttpStatusCodeInfo { Code = 412, Name = "Precondition Failed" } },
            { 413, new HttpStatusCodeInfo { Code = 413, Name = "Payload Too Large" } },
            { 414, new HttpStatusCodeInfo { Code = 414, Name = "URI Too Long" } },
            { 415, new HttpStatusCodeInfo { Code = 415, Name = "Unsupported Media Type" } },
            { 416, new HttpStatusCodeInfo { Code = 416, Name = "Range Not Satisfiable" } },
            { 417, new HttpStatusCodeInfo { Code = 417, Name = "Expectation Failed" } },
            { 418, new HttpStatusCodeInfo { Code = 418, Name = "I'm a teapot" } },
            { 421, new HttpStatusCodeInfo { Code = 421, Name = "Misdirected Request" } },
            { 422, new HttpStatusCodeInfo { Code = 422, Name = "Unprocessable Entity" } },
            { 423, new HttpStatusCodeInfo { Code = 423, Name = "Locked" } },
            { 424, new HttpStatusCodeInfo { Code = 424, Name = "Failed Dependency" } },
            { 425, new HttpStatusCodeInfo { Code = 425, Name = "Too Early" } },
            { 426, new HttpStatusCodeInfo { Code = 426, Name = "Upgrade Required" } },
            { 428, new HttpStatusCodeInfo { Code = 428, Name = "Precondition Required" } },
            { 429, new HttpStatusCodeInfo { Code = 429, Name = "Too Many Requests" } },
            { 431, new HttpStatusCodeInfo { Code = 431, Name = "Request Header Fields Too Large" } },
            { 451, new HttpStatusCodeInfo { Code = 451, Name = "Unavailable For Legal Reasons" } },

            { 500, new HttpStatusCodeInfo { Code = 500, Name = "Internal Server Error" } },
            { 501, new HttpStatusCodeInfo { Code = 501, Name = "Not Implemented" } },
            { 502, new HttpStatusCodeInfo { Code = 502, Name = "Bad Gateway" } },
            { 503, new HttpStatusCodeInfo { Code = 503, Name = "Service Unavailable" } },
            { 504, new HttpStatusCodeInfo { Code = 504, Name = "Gateway Timeout" } },
            { 505, new HttpStatusCodeInfo { Code = 505, Name = "HTTP Version Not Supported" } },
            { 506, new HttpStatusCodeInfo { Code = 506, Name = "Variant Also Negotiates" } },
            { 507, new HttpStatusCodeInfo { Code = 507, Name = "Insufficient Storage" } },
            { 508, new HttpStatusCodeInfo { Code = 508, Name = "Loop Detected" } },
            { 510, new HttpStatusCodeInfo { Code = 510, Name = "Not Extended" } },
            { 511, new HttpStatusCodeInfo { Code = 511, Name = "Network Authentication Required" } }
        };

        private HttpStatusCodeInfo()
        {
        }

        private HttpStatusCodeCategory _category;

        /// <summary>
        /// HTTP status code category.
        /// </summary>
        public HttpStatusCodeCategory Category => _category ?? (_category = HttpStatusCodeCategory.CreateFromHttpStatusCode(Code));

        /// <summary>
        /// HTTP status code.
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// Name for the HTTP status code.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.HttpStatusCode" /> class based
        /// on it's code.
        /// </summary>
        /// <param name="code">HTTP status code as an integer.</param>
        /// <returns>New instance of <see cref="T:ByteDev.Http.HttpStatusCode" />.</returns>
        public static HttpStatusCodeInfo CreateFromCode(int code)
        {
            try
            {
                return Statuses[code];
            }
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException($"No HTTP status code exists with code: {code}.", nameof(code), ex);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.HttpStatusCode" /> class based
        /// on it's code.
        /// </summary>
        /// <param name="code">HTTP status code as a <see cref="T:System.Net.HttpStatusCode" />.</param>
        /// <returns>New instance of <see cref="T:ByteDev.Http.HttpStatusCode" />.</returns>
        public static HttpStatusCodeInfo CreateFromCode(HttpStatusCode code)
        {
            return CreateFromCode((int)code);
        }

        public override string ToString()
        {
            return $"{Code} {Name}";
        }
    }
}