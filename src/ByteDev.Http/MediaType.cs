using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ByteDev.Http
{
    /// <summary>
    /// Represents an internet media type. Also known as a Multipurpose Internet
    /// Mail Extensions or MIME type. As defined in RFC 6838.
    /// </summary>
    /// <remarks>
    /// Media types have the form:
    /// "type/[tree.]subtype[+suffix] [;parameter]*"
    /// See: https://tools.ietf.org/html/rfc6838
    /// </remarks>
    public class MediaType
    {
        /// <summary>
        /// Current registered main types.
        /// </summary>
        public static readonly HashSet<string> RegisteredTypes = new HashSet<string>
        {
            "application",
            "audio",
            "example",
            "font",
            "image",
            "message",
            "model",
            "multipart",
            "text",
            "video"
        };

        /// <summary>
        /// Main type. Such as application, image etc.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Tree. Any part after the forward slash but before the last period.
        /// </summary>
        public string Tree { get; }

        /// <summary>
        /// Sub type. Part after the forward slash and any last period, but
        /// before any suffix.
        /// </summary>
        public string SubType { get; }

        /// <summary>
        /// Suffix. Any part after the plus sign but before any parameters.
        /// </summary>
        public string Suffix { get; }

        /// <summary>
        /// Parameters. Any name value parameters specified after a semicolon.
        /// </summary>
        public IDictionary<string, string> Parameters { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.MediaType" /> class.
        /// </summary>
        /// <param name="mediaType">
        /// A media type in format: "type/[tree.]subtype[+suffix] [;parameter]*"
        /// </param>
        public MediaType(string mediaType)
        {
            if (string.IsNullOrEmpty(mediaType))
                throw new ArgumentException("Media type was null or empty.", nameof(mediaType));

            if (mediaType.CountOccurrences('/') != 1)
                throw new ArgumentException("Media type was malformed. Must have exactly one forward slash.");

            if (mediaType.CountOccurrences('+') > 1)
                throw new ArgumentException("Media type was malformed. Must not have more than one plus character.");

            Type = GetType(mediaType);
            Tree = GetTree(mediaType);
            SubType = GetSubType(mediaType);
            Suffix = GetSuffix(mediaType);
            Parameters = GetParams(mediaType);
        }

        private static string GetType(string mediaType)
        {
            var match = Regex.Match(mediaType, "^(?<Type>.*)/");

            var type = match.Groups["Type"].Value;

            if (!RegisteredTypes.Contains(type))
                throw new ArgumentException("Media type does not have a registered type.");

            return type;
        }

        private static string GetSubType(string mediaType)
        {
            var match = Regex.Match(mediaType, @"\/((.*)(\.))*(?<SubType>.*?)((\+|;)|($))");

            return match.Groups["SubType"].Value;
        }

        private static string GetTree(string mediaType)
        {
            var match = Regex.Match(mediaType, @"\/(?<Tree>.*)\.");

            var tree = match.Groups["Tree"].Value;

            return tree == string.Empty ? null : tree;
        }

        private static string GetSuffix(string mediaType)
        {
            var match = Regex.Match(mediaType, @"\+(?<Suffix>.*?)((;)|($))");

            var suffix = match.Groups["Suffix"].Value;

            return suffix == string.Empty ? null : suffix;
        }

        private static IDictionary<string, string> GetParams(string mediaType)
        {
            var match = Regex.Match(mediaType, @";\s*(?<Params>.*?)$");

            var parameters = match.Groups["Params"].Value;

            var dict = new Dictionary<string, string>();

            if (parameters == string.Empty)
                return dict;

            var nameValuePairs = parameters.Trim().Split(';');

            foreach (var nameValuePair in nameValuePairs)
            {
                var pair = nameValuePair.Split('=');

                dict.Add(pair[0].Trim(), pair.Length > 1 ? pair[1].Trim() : null);
            }

            return dict;
        }

        public override string ToString()
        {
            var s = Type + "/";

            if (Tree == null)
            {
                s += SubType;
            }
            else
            {
                s += Tree + "." + SubType;
            }

            if (Suffix != null)
            {
                s += "+" + Suffix;
            }

            foreach (var param in Parameters)
            {
                s += $"; {param.Key}={param.Value}";
            }

            return s;
        }
    }
}