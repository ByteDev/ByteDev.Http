﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            if (mediaType.CountOccurrences('/') != 1)
                throw new ArgumentException("Media type was malformed. Must have exactly one forward slash.");

            if (mediaType.CountOccurrences('+') > 1)
                throw new ArgumentException("Media type was malformed. Must not have more than one plus character.");

            Type = GetType(mediaType);
            Tree = GetTree(mediaType);
            SubType = GetSubType(mediaType);
            Suffix = GetSuffix(mediaType);
            Parameter = GetParams(mediaType);
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

        private static string GetParams(string mediaType)
        {
            var match = Regex.Match(mediaType, @";\s*(?<Param>.*?)$");

            var param = match.Groups["Param"].Value;

            return param == string.Empty ? null : param;
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

            if (Parameter != null)
            {
                s += "; " + Parameter;
            }

            return s;
        }
    }
}