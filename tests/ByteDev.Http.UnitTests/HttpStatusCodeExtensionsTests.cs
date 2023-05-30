using System.Net;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpStatusCodeExtensionsTests
    {
        [Test]
        public void WhenIsNotDefined_ThenReturnCode()
        {
            var sut = (HttpStatusCode)999;

            var result = sut.ToReadableString();

            Assert.That(result, Is.EqualTo("999"));
        }

        [Test]
        public void WhenCodeIsDefined_ThenReturnCodeAndName()
        {
            var sut = HttpStatusCode.BadRequest;

            var result = sut.ToReadableString();

            Assert.That(result, Is.EqualTo("400 BadRequest"));
        }
    }
}