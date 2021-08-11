using System.Threading.Tasks;
using ByteDev.Http.Content;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests.Content
{
    [TestFixture]
    public class EmptyContentTests
    {
        [Test]
        public async Task WhenCallReadAsStringAsync_ThenReturnEmpty()
        {
            var sut = new EmptyContent();

            var result = await sut.ReadAsStringAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task WhenCallReadAsByteArrayAsync_ThenReturnEmpty()
        {
            var sut = new EmptyContent();

            var result = await sut.ReadAsByteArrayAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task WhenCallReadAsStreamAsync_ThenReturnEmpty()
        {
            var sut = new EmptyContent();
            
            var result = await sut.ReadAsStreamAsync();
            
            Assert.That(result.Length, Is.EqualTo(0));
        }
    }
}