using System;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class MediaTypeTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void WhenNameIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new MediaType(null));
            }

            [Test]
            public void WhenNameIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new MediaType(string.Empty));
            }

            [Test]
            public void WhenTypeNotRegistered_ThenThrowException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _ = new MediaType("myapplication/json"));
                Assert.That(ex.Message, Is.EqualTo("Media type does not have a registered type."));
            }

            [TestCase("application")]
            [TestCase("application/json/xml")]
            public void WhenIsMalformedWithDoesNotHaveSingleForwardSlash_ThenThrowException(string mediaType)
            {
                var ex = Assert.Throws<ArgumentException>(() => _ = new MediaType(mediaType));
                Assert.That(ex.Message, Is.EqualTo("Media type was malformed. Must have exactly one forward slash."));
            }

            [Test]
            public void WhenIsMalformedWithMultiplePlusChar_ThenThrowException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _ = new MediaType("application/vnd.api+json+xml"));
                Assert.That(ex.Message, Is.EqualTo("Media type was malformed. Must not have more than one plus character."));
            }

            [Test]
            public void WhenContainsOnlyTypeAndSubType_ThenSetsProperties()
            {
                var sut = new MediaType("application/json");

                Assert.That(sut.Type, Is.EqualTo("application"));
                Assert.That(sut.Tree, Is.Null);
                Assert.That(sut.SubType, Is.EqualTo("json"));
                Assert.That(sut.Suffix, Is.Null);
                Assert.That(sut.Parameters, Is.Empty);
            }

            [Test]
            public void WhenContainsTree_ThenSetsProperties()
            {
                var sut = new MediaType("application/vnd.ms-excel");

                Assert.That(sut.Type, Is.EqualTo("application"));
                Assert.That(sut.Tree, Is.EqualTo("vnd"));
                Assert.That(sut.SubType, Is.EqualTo("ms-excel"));
                Assert.That(sut.Suffix, Is.Null);
                Assert.That(sut.Parameters, Is.Empty);
            }

            [Test]
            public void WhenContainsMultipleTrees_ThenSetsProperties()
            {
                var sut = new MediaType("application/vnd.oasis.opendocument.text");

                Assert.That(sut.Type, Is.EqualTo("application"));
                Assert.That(sut.Tree, Is.EqualTo("vnd.oasis.opendocument"));
                Assert.That(sut.SubType, Is.EqualTo("text"));
                Assert.That(sut.Suffix, Is.Null);
                Assert.That(sut.Parameters, Is.Empty);
            }

            [Test]
            public void WhenContainsSuffix_ThenSetProperties()
            {
                var sut = new MediaType("application/vnd.api+json");

                Assert.That(sut.Type, Is.EqualTo("application"));
                Assert.That(sut.Tree, Is.EqualTo("vnd"));
                Assert.That(sut.SubType, Is.EqualTo("api"));
                Assert.That(sut.Suffix, Is.EqualTo("json"));
                Assert.That(sut.Parameters, Is.Empty);
            }

            [TestCase("text/html;charset=UTF-8")]
            [TestCase("text/html; charset=UTF-8 ")]
            [TestCase("text/html; charset = UTF-8 ")]
            public void WhenContainsParameter_ThenSetProperties(string mediaType)
            {
                var sut = new MediaType(mediaType);

                Assert.That(sut.Type, Is.EqualTo("text"));
                Assert.That(sut.Tree, Is.Null);
                Assert.That(sut.SubType, Is.EqualTo("html"));
                Assert.That(sut.Suffix, Is.Null);
                Assert.That(sut.Parameters["charset"], Is.EqualTo("UTF-8"));
            }

            [TestCase("text/html; charset=UTF-8; charset2=UTF-16")]
            public void WhenContainsTwoParameters_ThenSetProperties(string mediaType)
            {
                var sut = new MediaType(mediaType);

                Assert.That(sut.Type, Is.EqualTo("text"));
                Assert.That(sut.Tree, Is.Null);
                Assert.That(sut.SubType, Is.EqualTo("html"));
                Assert.That(sut.Suffix, Is.Null);
                Assert.That(sut.Parameters["charset"], Is.EqualTo("UTF-8"));
                Assert.That(sut.Parameters["charset2"], Is.EqualTo("UTF-16"));
            }

            [Test]
            public void WhenContainsEverything_ThenSetProperties()
            {
                var sut = new MediaType("application/vnd.api+json; charset=UTF-8");

                Assert.That(sut.Type, Is.EqualTo("application"));
                Assert.That(sut.Tree, Is.EqualTo("vnd"));
                Assert.That(sut.SubType, Is.EqualTo("api"));
                Assert.That(sut.Suffix, Is.EqualTo("json"));
                Assert.That(sut.Parameters["charset"], Is.EqualTo("UTF-8"));
            }
        }

        [TestFixture]
        public class ToStringOverride
        {
            [TestCase("application/json")]
            [TestCase("application/vnd.api")]
            [TestCase("application/vnd.api; charset=UTF-8")]
            [TestCase("application/vnd.api+json")]
            [TestCase("application/vnd.api+json; charset=UTF-8")]
            [TestCase("application/vnd.api+json; charset=UTF-8; charset2=UTF-16")]
            public void WhenAllPropertiesSet_ThenReturnString(string mediaType)
            {
                var sut = new MediaType(mediaType);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo(mediaType));
            }
        }
    }
}