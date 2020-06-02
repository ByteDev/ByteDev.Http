using System;
using System.Text;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    public static class FormUrlEncodedSerializer
    {
        public static string Serialize(object obj, SerializeOptions options = null)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (options == null)
                options = new SerializeOptions();

            var keyValues = obj.GetPropertiesAsDictionary();

            var sb = new StringBuilder();

            foreach (var keyValue in keyValues)
            {
                if (sb.Length > 0)
                    sb.Append('&');

                sb.Append(Encode(keyValue.Key, options));
                sb.Append("=");
                sb.Append(Encode(keyValue.Value, options));
            }

            return sb.ToString();
        }

        public static T Deserialize<T>(string formUrlEncodedText, DeserializeOptions options = null) where T : new()
        {
            if (string.IsNullOrEmpty(formUrlEncodedText))
                throw new ArgumentException("Form URL Encoded text was null or empty.", nameof(formUrlEncodedText));

            if (options == null)
                options = new DeserializeOptions();

            var pairs = formUrlEncodedText.Split('&');

            var obj = new T();

            foreach (var pair in pairs)
            {
                var nameValue = pair.Split('=');

                if (HasValue(nameValue))
                {
                    var name = Decode(nameValue[0], options);
                    var value = Decode(nameValue[1], options);

                    obj.SetPublicProperty(name, value);
                }
            }

            return obj;
        }

        private static bool HasValue(string[] nameValue)
        {
            return nameValue.Length == 2 && nameValue[1] != string.Empty;
        }

        private static string Encode(string value, SerializeOptions options)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (!options.Encode)
                return value;

            var escapedValue = Uri.EscapeDataString(value);

            if (options.EncodeSpaceAsPlus)
            {
                return escapedValue.Replace("%20", "+");
            }

            return escapedValue;
        }

        private static string Decode(string value, DeserializeOptions options)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (!options.Decode)
                return value;

            var unescapedValue = value;

            if (options.DecodePlusAsSpace)
                unescapedValue = unescapedValue.Replace("+", "%20");

            return Uri.UnescapeDataString(unescapedValue);
        }
    }
}