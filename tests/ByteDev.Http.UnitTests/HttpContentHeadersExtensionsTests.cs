using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpContentHeadersExtensionsTests
    {
        [TestFixture]
        public class AddOrUpdate : HttpContentHeadersExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => HttpContentHeadersExtensions.AddOrUpdate(null, "Name1", "Value1"));
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

            private static HttpContentHeaders CreateSut()
            {
                return new StringContent("Some content").Headers;
            }
        }  
    }
}