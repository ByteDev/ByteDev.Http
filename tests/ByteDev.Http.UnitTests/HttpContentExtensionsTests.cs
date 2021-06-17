using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpContentExtensionsTests
    {
        [TestFixture]
        public class ReadAsJsonAsync : HttpContentExtensionsTests
        {
            [Test]
            public void WhenContentIsNull_ThenThrowException()
            {
                Assert.ThrowsAsync<ArgumentNullException>(() => HttpContentExtensions.ReadAsJsonAsync<TestDummy>(null));
            }

            [Test]
            public async Task WhenContentIsJson_ThenReturnObj()
            {
                var dummy = new TestDummy {Name = "John"};
                var json = JsonSerializer.Serialize(dummy);

                var sut = new StringContent(json);

                var result = await sut.ReadAsJsonAsync<TestDummy>();

                Assert.That(result.Name, Is.EqualTo(dummy.Name));
            }
        }

        [TestFixture]
        public class ReadAsXmlAsync : HttpContentExtensionsTests
        {
            [Test]
            public void WhenContentIsNull_ThenThrowException()
            {
                Assert.ThrowsAsync<ArgumentNullException>(() => HttpContentExtensions.ReadAsJsonAsync<TestDummy>(null));
            }

            [Test]
            public async Task WhenContentIsXml_ThenReturnObj()
            {
                var dummy = new TestDummy {Name = "John"};

                var xml = XmlDataSerializer.Serialize(dummy);

                var sut = new StringContent(xml);

                var result = await sut.ReadAsXmlAsync<TestDummy>();

                Assert.That(result.Name, Is.EqualTo(dummy.Name));
            }
        }
    }
}