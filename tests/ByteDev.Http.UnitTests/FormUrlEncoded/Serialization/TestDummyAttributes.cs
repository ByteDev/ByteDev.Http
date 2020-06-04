using ByteDev.Http.FormUrlEncoded.Serialization;

namespace ByteDev.Http.UnitTests.FormUrlEncoded.Serialization
{
    internal class TestDummyAttributes
    {
        public string Name { get; set; }

        [FormUrlEncodedPropertyName("emailAddress")]
        public string Email { get; set; }
    }
}