using System;
using System.Net;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpStatusCodeInfoTests
    {
        [TestFixture]
        public class CreateFromCode
        {
            [Test]
            public void WhenDoesNotExist_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => HttpStatusCodeInfo.CreateFromCode(999));
            }

            [Test]
            public void WhenExists_ThenReturnsInfo()
            {
                var result = HttpStatusCodeInfo.CreateFromCode(100);

                Assert.That(result.Code, Is.EqualTo(100));
                Assert.That(result.Name, Is.EqualTo("Continue"));
                Assert.That(result.Category.Code, Is.EqualTo(1));
            }

            [Test]
            public void WhenCodeIsHttpStatusCodeEnum_AndExists_ThenReturnInfo()
            {
                var result = HttpStatusCodeInfo.CreateFromCode(HttpStatusCode.Continue);

                Assert.That(result.Code, Is.EqualTo(100));
                Assert.That(result.Name, Is.EqualTo("Continue"));
                Assert.That(result.Category.Code, Is.EqualTo(1));
            }
        }
    }
}