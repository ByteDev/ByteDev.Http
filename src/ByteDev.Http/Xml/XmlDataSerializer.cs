using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ByteDev.Http.Xml
{
    internal static class XmlDataSerializer
    {
        public static string Serialize(object obj)
        {
            var xmlWriterSettings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8
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

            using (var stringReader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}