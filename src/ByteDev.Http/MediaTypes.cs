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

        public static class Audio
        {
            /// <summary>
            /// Usually for files of type: mid, midi, kar.
            /// </summary>
            public static readonly string Midi = "audio/midi";

            /// <summary>
            /// Usually for files of type: aac, f4a, f4b, m4a.
            /// </summary>
            public static readonly string Mp4 = "audio/mp4";

            public static readonly string Mp3 = "audio/mpeg";

            /// <summary>
            /// Usually for files of type: oga, ogg, opus.
            /// </summary>
            public static readonly string Ogg = "audio/ogg";

            /// <summary>
            /// Usually for files of type: ra.
            /// </summary>
            public static readonly string ReadAudio = "audio/x-realaudio";

            /// <summary>
            /// Usually for files of type: wav.
            /// </summary>
            public static readonly string Wav = "audio/x-wav ";

            /// <summary>
            /// Usually for file of type: mka.
            /// </summary>
            public static readonly string Matroska = "audio/x-matroska";
        }

        public static class Video
        {
            /// <summary>
            /// Usually for files of type: 3gp, 3gpp.
            /// </summary>
            public static readonly string ThreeGpp = "video/3gpp";

            /// <summary>
            /// Usually for files of type: f4p, f4v, m4v, mp4.
            /// </summary>
            public static readonly string Mp4 = "video/mp4";

            /// <summary>
            /// Usually for files of type: mpeg, mpg.
            /// </summary>
            public static readonly string Mpeg = "video/mpeg";

            /// <summary>
            /// Usually for files of type: ogv.
            /// </summary>
            public static readonly string Ogg = "video/ogg ";

            /// <summary>
            /// Usually for files of type: mov, qt.
            /// </summary>
            public static readonly string QuickTime = "video/quicktime";

            /// <summary>
            /// Usually for files of type: webm.
            /// </summary>
            public static readonly string WebM = "video/webm";

            /// <summary>
            /// Usually for files of type: flv.
            /// </summary>
            public static readonly string Flash = "video/x-flv";

            /// <summary>
            /// Usually for files of type: asf asx.
            /// </summary>
            public static readonly string Asf = "video/x-ms-asf";

            /// <summary>
            /// Usually for files of type: wmv.
            /// </summary>
            public static readonly string Wmv = "video/x-ms-wmv";

            /// <summary>
            /// Usually for files of type: avi.
            /// </summary>
            public static readonly string Avi = "video/x-msvideo";

            /// <summary>
            /// Usually for files of type: mkv mk3d.
            /// </summary>
            public static readonly string Matroska = "video/x-matroska";
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

            public static readonly string FormUrlEncoded = "application/x-www-form-urlencoded";

            public static readonly string Atom = "application/atom+xml";

            public static readonly string Rss = "application/rss+xml";

            public static readonly string Rdf = "application/rdf+xml";
        }
    }
}