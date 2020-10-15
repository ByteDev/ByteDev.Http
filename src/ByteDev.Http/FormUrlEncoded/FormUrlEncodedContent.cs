using System.Net.Http;
using System.Text;

namespace ByteDev.Http.FormUrlEncoded
{
    public class FormUrlEncodedContent : StringContent
    {
        public FormUrlEncodedContent(string content)
            : this(content, Encoding.UTF8)
        {
        }

        public FormUrlEncodedContent(string content, Encoding encoding)
            : base(content, encoding, "application/x-www-form-urlencoded")
        {
        }
    }
}