using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ByteDev.Http.FormUrlEncoded.Serialization;
using ByteDev.Xml.Serialization;

namespace ByteDev.Http
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            string content = await source.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content);
        }

        public static async Task<T> ReadAsXmlAsync<T>(this HttpContent source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            string content = await source.ReadAsStringAsync();

            return new XmlDataSerializer().Deserialize<T>(content);
        }

        public static async Task<T> ReadAsFormUrlEncodedAsync<T>(this HttpContent source, DeserializeOptions options = null) where T : new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            string content = await source.ReadAsStringAsync();

            return FormUrlEncodedSerializer.Deserialize<T>(content, options);
        }
    }
}