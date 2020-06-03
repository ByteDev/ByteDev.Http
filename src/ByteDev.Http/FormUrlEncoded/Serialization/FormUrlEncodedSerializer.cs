using System;
using System.Text;

namespace ByteDev.Http.FormUrlEncoded.Serialization
{
    /// <summary>
    /// Represents a serializer for form URL encoded (x-www-form-urlencoded) content.
    /// </summary>
    public static class FormUrlEncodedSerializer
    {
        /// <summary>
        /// Serialize an object to a form URL encoded string.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <returns>Form URL encoded string.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="obj" /> is null.</exception>
        public static string Serialize(object obj)
        {
            return Serialize(obj, new SerializeOptions());
        }

        /// <summary>
        /// Serialize an object to a form URL encoded string.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="options">Serialize options.</param>
        /// <returns>Form URL encoded string.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="obj" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="options" /> is null.</exception>
        public static string Serialize(object obj, SerializeOptions options)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var keyValues = obj.GetPropertiesAsDictionary();

            var sb = new StringBuilder();

            foreach (var keyValue in keyValues)
            {
                if (sb.Length > 0)
                    sb.Append('&');

                sb.Append(FormUrlEncodedEncoder.Encode(keyValue.Key, options));
                sb.Append("=");
                sb.Append(FormUrlEncodedEncoder.Encode(keyValue.Value, options));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Deserialize a form URL encoded string to an object.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize to.</typeparam>
        /// <param name="formUrlEncodedData">Form URL encoded string to deserialize.</param>
        /// <returns>Object of type <typeparamref name="T" />.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="formUrlEncodedData" /> is null or empty.</exception>
        public static T Deserialize<T>(string formUrlEncodedData) where T : new()
        {
            return Deserialize<T>(formUrlEncodedData, new DeserializeOptions());
        }

        /// <summary>
        /// Deserialize a form URL encoded string to an object.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize to.</typeparam>
        /// <param name="formUrlEncodedData">Form URL encoded string to deserialize.</param>
        /// <param name="options">Deserialize options.</param>
        /// <returns>Object of type <typeparamref name="T" />.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="formUrlEncodedData" /> is null or empty.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="options" /> is null.</exception>
        public static T Deserialize<T>(string formUrlEncodedData, DeserializeOptions options) where T : new()
        {
            if (string.IsNullOrEmpty(formUrlEncodedData))
                throw new ArgumentException("Form URL encoded data was null or empty.", nameof(formUrlEncodedData));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var pairs = formUrlEncodedData.Split('&');

            var obj = new T();

            foreach (var pair in pairs)
            {
                var nameValue = pair.Split('=');

                if (HasValue(nameValue))
                {
                    var name = FormUrlEncodedEncoder.Decode(nameValue[0], options);
                    var value = FormUrlEncodedEncoder.Decode(nameValue[1], options);

                    obj.SetPublicProperty(name, value);
                }
            }

            return obj;
        }

        private static bool HasValue(string[] nameValue)
        {
            return nameValue.Length == 2 && nameValue[1] != string.Empty;
        }
    }
}