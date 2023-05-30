using System;
using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.Http.Content;
using NUnit.Framework;
using FormUrlEncodedContent = ByteDev.Http.Content.FormUrlEncodedContent;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpContentExtensionsTests
    {
        private const string Json = "{ \"IsSuccess\": true } ";
        private const string Xml = "<data></data>";
        private const string FormUrlEncoded = "name1=value1&name2=value2";

        [TestFixture]
        public class IsJson : HttpContentExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => HttpContentExtensions.IsJson(null));
            }

            [Test]
            public void WhenHasNoContentType_ThenReturnFalse()
            {
                var sut = new EmptyContent();

                var result = sut.IsJson();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenNonJsonContentType_ThenReturnFalse()
            {
                var sut = new XmlContent(Xml);

                var result = sut.IsJson();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsJson_ThenReturnTrue()
            {
                var sut = new JsonContent(Json);

                var result = sut.IsJson();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsXml : HttpContentExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => HttpContentExtensions.IsXml(null));
            }

            [Test]
            public void WhenHasNoContentType_ThenReturnFalse()
            {
                var sut = new EmptyContent();

                var result = sut.IsXml();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenNonXmlContentType_ThenReturnFalse()
            {
                var sut = new JsonContent(Json);

                var result = sut.IsXml();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsXml_ThenReturnTrue()
            {
                var sut = new XmlContent(Xml);

                var result = sut.IsXml();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsFormUrlEncoded : HttpContentExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => HttpContentExtensions.IsFormUrlEncoded(null));
            }

            [Test]
            public void WhenHasNoContentType_ThenReturnFalse()
            {
                var sut = new EmptyContent();

                var result = sut.IsFormUrlEncoded();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenNonXmlContentType_ThenReturnFalse()
            {
                var sut = new JsonContent(Json);

                var result = sut.IsFormUrlEncoded();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsFormUrlEncoded_ThenReturnTrue()
            {
                var sut = new FormUrlEncodedContent(FormUrlEncoded);

                var result = sut.IsFormUrlEncoded();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class SafeReadAsStringAsync : HttpContentExtensionsTests
        {
            [Test]
            public async Task WhenSourceIsNull_ThenReturnEmpty()
            {
                var result = await HttpContentExtensions.SafeReadAsStringAsync(null);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public async Task WhenIsEmpty_ThenReturnEmpty()
            {
                var sut = new EmptyContent();

                var result = await sut.SafeReadAsStringAsync();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public async Task WhenHasString_ThenReturnString()
            {
                const string content = "Test string";

                var sut = new StringContent(content);

                var result = await sut.SafeReadAsStringAsync();

                Assert.That(result, Is.EqualTo(content));
            }
        }
    }
}