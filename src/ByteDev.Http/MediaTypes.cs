namespace ByteDev.Http
{
    /// <summary>
    /// Represents common media types.
    /// </summary>
    /// <remarks>
    /// See:
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types
    /// https://www.iana.org/assignments/media-types/media-types.xhtml
    /// </remarks>
    public static class MediaTypes
    {
        public static class Text
        {
            public static readonly string Plain = "text/plain";

            public static readonly string Html = "text/html";

            public static readonly string Css = "text/css";

            public static readonly string JavaScript = "text/javascript";
        }
        
        public static class Image
        {
            public static readonly string Apng = "image/apng";

            public static readonly string Bmp = "image/bmp";

            public static readonly string Gif = "image/gif";

            public static readonly string MicrosoftIcon = "image/x-icon";

            public static readonly string Jpeg = "image/jpeg";

            public static readonly string Png = "image/png";

            public static readonly string Svg = "image/svg+xml";

            public static readonly string Tiff = "image/tiff";

            public static readonly string WebP = "image/webp";
        }

        public static class Multipart
        {
            public static readonly string FormData = "multipart/form-data";

            public static readonly string ByteRanges = "multipart/byteranges";
        }

        public static class Application
        {
            public static readonly string Json = "application/json";

            public static readonly string Xml = "application/xml";
        }
    }
}