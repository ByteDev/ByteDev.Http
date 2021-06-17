using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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

            return XmlDataSerializer.Deserialize<T>(content);
        }
    }
}