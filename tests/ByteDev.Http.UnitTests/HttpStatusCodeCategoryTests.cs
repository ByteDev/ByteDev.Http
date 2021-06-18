using System;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class HttpStatusCodeCategoryTests
    {
        [TestFixture]
        public class CreateFromCategoryCode
        {
            [TestCase(-1)]
            [TestCase(0)]
            [TestCase(6)]
            public void WhenCategoryDoesNotExist_ThenThrowException(int categoryCode)
            {
                Assert.Throws<ArgumentException>(() => HttpStatusCodeCategory.CreateFromCategoryCode(categoryCode));
            }

            [TestCase(1, "Informational")]
            [TestCase(2, "Success")]
            [TestCase(3, "Redirection")]
            [TestCase(4, "Client Error")]
            [TestCase(5, "Server Error")]
            public void WhenCategoryExists_ThenReturnCategory(int code, string name)
            {
                var result = HttpStatusCodeCategory.CreateFromCategoryCode(code);

                Assert.That(result.Code, Is.EqualTo(code));
                Assert.That(result.Name, Is.EqualTo(name));
                Assert.That(result.Description.Length, Is.GreaterThan(0));
            }
        }

        [TestFixture]
        public class CreateFromHttpStatusCode
        {
            [TestCase(99)]
            [TestCase(600)]
            public void WhenHttpStatusCodeNotValid_ThenThrowException(int statusCode)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => HttpStatusCodeCategory.CreateFromHttpStatusCode(statusCode));
            }

            [TestCase(100, 1)]
            [TestCase(199, 1)]
            [TestCase(200, 2)]
            [TestCase(299, 2)]
            [TestCase(300, 3)]
            [TestCase(399, 3)]
            [TestCase(400, 4)]
            [TestCase(499, 4)]
            [TestCase(500, 5)]
            [TestCase(599, 5)]
            public void WhenCategoryExists_ThenReturnCategory(int statusCode, int expected)
            {
                var result = HttpStatusCodeCategory.CreateFromHttpStatusCode(statusCode);

                Assert.That(result.Code, Is.EqualTo(expected));
            }
        }
    }
}