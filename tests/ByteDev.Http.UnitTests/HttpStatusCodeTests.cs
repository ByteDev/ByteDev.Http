using System;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpStatusCodeTests
    {
        [TestFixture]
        public class CreateFromCode
        {
            [Test]
            public void WhenDoesNotExist_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => HttpStatusCode.CreateFromCode(999));
            }

            [Test]
            public void WhenExists_ThenReturnsObject()
            {
                var result = HttpStatusCode.CreateFromCode(100);

                Assert.That(result.Code, Is.EqualTo(100));
                Assert.That(result.Name, Is.EqualTo("Continue"));
                Assert.That(result.Category.Code, Is.EqualTo(1));
            }
        }
    }
}