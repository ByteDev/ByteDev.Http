using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpRequestHeadersExtensionsTests
    {
        private readonly Assembly Assembly = Assembly.GetAssembly(typeof(HttpRequestHeadersExtensionsTests));

        private static HttpRequestHeaders CreateSut()
        {
            return new HttpRequestMessage().Headers;
        }

        [TestFixture]
        public class AddUserAgent : HttpRequestHeadersExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => HttpRequestHeadersExtensions.AddUserAgent(null, Assembly));
            }

            [Test]
            public void WhenAssemblyIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => CreateSut().AddUserAgent(null));
            }

            [Test]
            public void WhenAssemblyProvided_ThenAddUserAgent()
            {
                var sut = CreateSut();

                sut.AddUserAgent(Assembly);

                Assert.That(sut.UserAgent.Single().ToString(), Is.EqualTo("ByteDevHttpUnitTests/1.0.0"));
            }
        }

        [TestFixture]
        public class AddOrUpdate : HttpRequestHeadersExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => HttpRequestHeadersExtensions.AddOrUpdate(null, "Name1", "Value1"));
            }

            [Test]
            public void WhenDoesNotContainName_ThenAdd()
            {
                var sut = CreateSut();

                sut.AddOrUpdate("Name1", "Value1");

                var result = sut.GetValues("Name1");

                Assert.That(result.Single(), Is.EqualTo("Value1"));
            }

            [Test]
            public void WhenDoesContainName_ThenUpdate()
            {
                var sut = CreateSut();

                sut.AddOrUpdate("Name1", "Value1");
                sut.AddOrUpdate("Name1", "Value2");

                var result = sut.GetValues("Name1");

                Assert.That(result.Single(), Is.EqualTo("Value2"));
            }
        }
    }
}