using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ByteDev.Http.Xml
{
    internal static class XmlDataSerializer
    {
        public static string Serialize(object obj, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            var xmlWriterSettings = new XmlWriterSettings
            {
                Encoding = encoding
            };

            using (var sw = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(sw, xmlWriterSettings))
                {
                    var xmlSerializer = new XmlSerializer(obj.GetType());

                    xmlSerializer.Serialize(xmlWriter, obj);
                }

                return sw.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return default;

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(sr);
            }
        }
    }
}