using System;
using System.Collections.Generic;

namespace ByteDev.Http
{
    /// <summary>
    /// Represents a standard HTTP status code with extended information.
    /// </summary>
    /// <remarks>
    /// Full list of codes can be viewed at Wikipedia:
    /// https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
    /// </remarks>
    public class HttpStatusCode
    {
        private static readonly IDictionary<int, HttpStatusCode> Statuses = new Dictionary<int, HttpStatusCode>
        {
            { 100, new HttpStatusCode { Code = 100, Name = "Continue" } },
            { 101, new HttpStatusCode { Code = 101, Name = "Switching Protocols" } },
            { 102, new HttpStatusCode { Code = 102, Name = "Processing" } },
            { 103, new HttpStatusCode { Code = 103, Name = "Early Hints" } },

            { 200, new HttpStatusCode { Code = 200, Name = "OK" } },
            { 201, new HttpStatusCode { Code = 201, Name = "Created" } },
            { 202, new HttpStatusCode { Code = 202, Name = "Accepted" } },
            { 203, new HttpStatusCode { Code = 203, Name = "Non-authoritative Information" } },
            { 204, new HttpStatusCode { Code = 204, Name = "No Content" } },
            { 205, new HttpStatusCode { Code = 205, Name = "Reset Content" } },
            { 206, new HttpStatusCode { Code = 206, Name = "Partial Content" } },
            { 207, new HttpStatusCode { Code = 207, Name = "Multi-Status" } },
            { 208, new HttpStatusCode { Code = 208, Name = "Already Reported" } },
            { 226, new HttpStatusCode { Code = 226, Name = "IM Used" } },

            { 300, new HttpStatusCode { Code = 300, Name = "Multiple Choices" } },
            { 301, new HttpStatusCode { Code = 301, Name = "Moved Permanently" } },
            { 302, new HttpStatusCode { Code = 302, Name = "Found" } },                 // used to be "Moved Temporarily"
            { 303, new HttpStatusCode { Code = 303, Name = "See Other" } },
            { 304, new HttpStatusCode { Code = 304, Name = "Not Modified" } },
            { 305, new HttpStatusCode { Code = 305, Name = "Use Proxy" } },
            { 306, new HttpStatusCode { Code = 306, Name = "Switch Proxy" } },
            { 307, new HttpStatusCode { Code = 307, Name = "Temporary Redirect" } },
            { 308, new HttpStatusCode { Code = 308, Name = "Permanent Redirect" } },

            { 400, new HttpStatusCode { Code = 400, Name = "Bad Request" } },
            { 401, new HttpStatusCode { Code = 401, Name = "Unauthorized" } },
            { 402, new HttpStatusCode { Code = 402, Name = "Payment Required" } },
            { 403, new HttpStatusCode { Code = 403, Name = "Forbidden" } },
            { 404, new HttpStatusCode { Code = 404, Name = "Not Found" } },
            { 405, new HttpStatusCode { Code = 405, Name = "Method Not Allowed" } },
            { 406, new HttpStatusCode { Code = 406, Name = "Not Acceptable" } },
            { 407, new HttpStatusCode { Code = 407, Name = "Proxy Authentication Required" } },
            { 408, new HttpStatusCode { Code = 408, Name = "Request Timeout" } },
            { 409, new HttpStatusCode { Code = 409, Name = "Conflict" } },
            { 410, new HttpStatusCode { Code = 410, Name = "Gone" } },
            { 411, new HttpStatusCode { Code = 411, Name = "Length Required" } },
            { 412, new HttpStatusCode { Code = 412, Name = "Precondition Failed" } },
            { 413, new HttpStatusCode { Code = 413, Name = "Payload Too Large" } },
            { 414, new HttpStatusCode { Code = 414, Name = "URI Too Long" } },
            { 415, new HttpStatusCode { Code = 415, Name = "Unsupported Media Type" } },
            { 416, new HttpStatusCode { Code = 416, Name = "Range Not Satisfiable" } },
            { 417, new HttpStatusCode { Code = 417, Name = "Expectation Failed" } },
            { 418, new HttpStatusCode { Code = 418, Name = "I'm a teapot" } },
            { 421, new HttpStatusCode { Code = 421, Name = "Misdirected Request" } },
            { 422, new HttpStatusCode { Code = 422, Name = "Unprocessable Entity" } },
            { 423, new HttpStatusCode { Code = 423, Name = "Locked" } },
            { 424, new HttpStatusCode { Code = 424, Name = "Failed Dependency" } },
            { 425, new HttpStatusCode { Code = 425, Name = "Too Early" } },
            { 426, new HttpStatusCode { Code = 426, Name = "Upgrade Required" } },
            { 428, new HttpStatusCode { Code = 428, Name = "Precondition Required" } },
            { 429, new HttpStatusCode { Code = 429, Name = "Too Many Requests" } },
            { 431, new HttpStatusCode { Code = 431, Name = "Request Header Fields Too Large" } },
            { 451, new HttpStatusCode { Code = 451, Name = "Unavailable For Legal Reasons" } },

            { 500, new HttpStatusCode { Code = 500, Name = "Internal Server Error" } },
            { 501, new HttpStatusCode { Code = 501, Name = "Not Implemented" } },
            { 502, new HttpStatusCode { Code = 502, Name = "Bad Gateway" } },
            { 503, new HttpStatusCode { Code = 503, Name = "Service Unavailable" } },
            { 504, new HttpStatusCode { Code = 504, Name = "Gateway Timeout" } },
            { 505, new HttpStatusCode { Code = 505, Name = "HTTP Version Not Supported" } },
            { 506, new HttpStatusCode { Code = 506, Name = "Variant Also Negotiates" } },
            { 507, new HttpStatusCode { Code = 507, Name = "Insufficient Storage" } },
            { 508, new HttpStatusCode { Code = 508, Name = "Loop Detected" } },
            { 510, new HttpStatusCode { Code = 510, Name = "Not Extended" } },
            { 511, new HttpStatusCode { Code = 511, Name = "Network Authentication Required" } }
        };

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
        /// <param name="code">HTTP status code.</param>
        /// <returns>New instance of <see cref="T:ByteDev.Http.HttpStatusCode" />.</returns>
        public static HttpStatusCode CreateFromCode(int code)
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

        public override string ToString()
        {
            return $"{Code} {Name}";
        }
    }
}