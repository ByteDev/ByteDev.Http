using System;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpStatusCodeCategoryTests
    {
        [TestFixture]
        public class CreateFromCode
        {
            [Test]
            public void WhenCategoryDoesNotExist_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => HttpStatusCodeCategory.CreateFromCode(6));
            }

            [TestCase(1, "Informational")]
            [TestCase(2, "Success")]
            [TestCase(3, "Redirection")]
            [TestCase(4, "Client Error")]
            [TestCase(5, "Server Error")]
            public void WhenCategoryExists_ThenReturnCategory(int code, string name)
            {
                var result = HttpStatusCodeCategory.CreateFromCode(code);

                Assert.That(result.Code, Is.EqualTo(code));
                Assert.That(result.Name, Is.EqualTo(name));
                Assert.That(result.Description.Length, Is.GreaterThan(0));
            }
        }

        [TestFixture]
        public class CreateFromHttpStatusCode
        {
            [Test]
            public void WhenHttpStatusCodeNotValid_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => HttpStatusCodeCategory.CreateFromHttpStatusCode(99));
            }

            [Test]
            public void WhenCategoryDoesNotExist_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => HttpStatusCodeCategory.CreateFromHttpStatusCode(601));
            }

            [Test]
            public void WhenCategoryExists_ThenReturnCategory()
            {
                var result = HttpStatusCodeCategory.CreateFromHttpStatusCode(100);

                Assert.That(result.Code, Is.EqualTo(1));
            }
        }
    }
}