using System;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests
{
    [TestFixture]
    public class MediaTypeTests
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
            Assert.Throws<ArgumentException>(() => _ = new MediaType("myapplication/json"));
        }

        [TestCase("application")]
        [TestCase("application/vnd.ms.ms-excel")]
        [TestCase("application/vnd.api+json+xml")]
        [TestCase("text/html; charset=UTF-8; charset=UTF-16")]
        public void WhenIsMalformed_ThenThrowException(string mediaType)
        {
            var ex = Assert.Throws<ArgumentException>(() => _ = new MediaType(mediaType));
            Assert.That(ex.Message, Is.EqualTo("Media type was malformed."));
        }

        [Test]
        public void WhenContainsOnlyTypeAndSubType_ThenSetsProperties()
        {
            var sut = new MediaType("application/json");

            Assert.That(sut.Type, Is.EqualTo("application"));
            Assert.That(sut.Tree, Is.Null);
            Assert.That(sut.SubType, Is.EqualTo("json"));
            Assert.That(sut.Suffix, Is.Null);
            Assert.That(sut.Parameter, Is.Null);
        }

        [Test]
        public void WhenContainsTree_ThenSetsProperties()
        {
            var sut = new MediaType("application/vnd.ms-excel");

            Assert.That(sut.Type, Is.EqualTo("application"));
            Assert.That(sut.Tree, Is.EqualTo("vnd"));
            Assert.That(sut.SubType, Is.EqualTo("ms-excel"));
            Assert.That(sut.Suffix, Is.Null);
            Assert.That(sut.Parameter, Is.Null);
        }

        [Test]
        public void WhenContainsSuffix_ThenSetProperties()
        {
            var sut = new MediaType("application/vnd.api+json");

            Assert.That(sut.Type, Is.EqualTo("application"));
            Assert.That(sut.Tree, Is.EqualTo("vnd"));
            Assert.That(sut.SubType, Is.EqualTo("api"));
            Assert.That(sut.Suffix, Is.EqualTo("json"));
            Assert.That(sut.Parameter, Is.Null);
        }

        [Test]
        public void WhenContainsParameter_ThenSetProperties()
        {
            var sut = new MediaType("text/html; charset=UTF-8");

            Assert.That(sut.Type, Is.EqualTo("text"));
            Assert.That(sut.Tree, Is.Null);
            Assert.That(sut.SubType, Is.EqualTo("html"));
            Assert.That(sut.Suffix, Is.Null);
            Assert.That(sut.Parameter, Is.EqualTo("charset=UTF-8"));
        }

        [Test]
        public void WhenContainsEverything_ThenSetProperties()
        {
            var sut = new MediaType("application/vnd.api+json; charset=UTF-8");

            Assert.That(sut.Type, Is.EqualTo("application"));
            Assert.That(sut.Tree, Is.EqualTo("vnd"));
            Assert.That(sut.SubType, Is.EqualTo("api"));
            Assert.That(sut.Suffix, Is.EqualTo("json"));
            Assert.That(sut.Parameter, Is.EqualTo("charset=UTF-8"));
        }
    }
}