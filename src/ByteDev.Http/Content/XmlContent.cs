using System.Net.Http;
using System.Text;

namespace ByteDev.Http.Content
{
    public class XmlContent : StringContent
    {
        public XmlContent(string content)
            : this(content, Encoding.UTF8)
        {
        }

        public XmlContent(string content, Encoding encoding)
            : base(content, encoding, "application/xml")
        {
        }
    }
}