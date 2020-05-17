using System;
using System.Collections.Generic;

namespace ByteDev.Http
{
    /// <summary>
    /// Represents an internet media type. Also known as a Multipurpose Internet
    /// Mail Extensions or MIME type. As defined in RFC 6838.
    /// </summary>
    /// <remarks>
    /// See: https://tools.ietf.org/html/rfc6838
    /// </remarks>
    public class MediaType
    {
        private const string MalformedMessage = "Media type was malformed.";

        private static readonly HashSet<string> RegisteredTypes = new HashSet<string>
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
        /// Type. Such as application, image, text etc.
        /// </summary>
        public string Type { get; }

        public string Tree { get; }

        public string SubType { get; }

        public string Suffix { get; }

        public string Parameter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Http.MediaType" /> class.
        /// </summary>
        /// <param name="mediaType">
        /// A media type in format: "type/[tree.]subtype[+suffix] [;parameter]"
        /// </param>
        public MediaType(string mediaType)
        {
            if (string.IsNullOrEmpty(mediaType))
                throw new ArgumentException("Media type was null or empty.", nameof(mediaType));

            var parts = mediaType.Split('/');

            Type = GetType(parts);

            var right = parts[1];

            Tree = GetTree(right);
            Parameter = GetParameter(right);

            var treeLen = Tree.SafeLength() == 0 ? 0 : Tree.SafeLength() + 1;
            var paramLen = Parameter.SafeLength() == 0 ? 0 : Parameter.SafeLength() + 1;

            var arr = right.Split('+');

            if (arr.Length == 1)
            {
                var suffixLen = Suffix.SafeLength() == 0 ? 0 : Suffix.SafeLength() + 1;

                var s = arr[0].Substring(treeLen);

                SubType = s.Substring(0, s.Length - (suffixLen + paramLen));
            }
            else if (arr.Length == 2)
            {
                SubType = arr[0].Substring(treeLen);
                Suffix = arr[1].Substring(0, arr[1].Length - paramLen);
            }
            else
            {
                throw new ArgumentException(MalformedMessage);
            }

            Parameter = Parameter?.Trim();
        }

        private static string GetType(string[] parts)
        {
            if (parts.Length != 2)
                throw new ArgumentException(MalformedMessage);

            if (!RegisteredTypes.Contains(parts[0]))
                throw new ArgumentException("Media type does not have a registered type.");

            return parts[0];
        }

        private static string GetTree(string right)
        {
            var parts = right.Split('.');

            if (parts.Length >= 2)
            {
                var tree = string.Empty;

                for (var i = 0; i < parts.Length - 1; i++)
                {
                    if (tree != string.Empty)
                        tree += ".";

                    tree += parts[i];
                }

                return tree;
            }

            return null;
        }

        // TODO: change so can handle multiple parameters

        private static string GetParameter(string right)
        {
            var parts = right.Split(';');

            if (parts.Length == 1)
                return null;

            if (parts.Length == 2)
                return parts[1];

            throw new ArgumentException(MalformedMessage);
        }

        public override string ToString()
        {
            var s = Type + "/";

            if (string.IsNullOrEmpty(Tree))
            {
                s += SubType;
            }
            else
            {
                s += Tree + "." + SubType;
            }

            if (!string.IsNullOrEmpty(Suffix))
            {
                s += "+" + Suffix;
            }

            if (!string.IsNullOrEmpty(Parameter))
            {
                s += "; " + Parameter;
            }

            return s;
        }
    }
}