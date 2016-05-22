using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using ExcellaCareers.Services;
using ExcellaCareers.Services.Impl;
using Moq;
using NUnit.Framework;

namespace ExcellaCareers.Tests.Services
{
    [TestFixture]
    public class HtmlScraperTests
    {
        private HtmlScraper ClassUnderTest { get; set; }

        private AutoMoqer Mocker { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Mocker = new AutoMoqer();
            this.ClassUnderTest = this.Mocker.Create<HtmlScraper>();
        }

        [Test]
        public void Scrape_GivenValidWebResponse_ExpectValidHtml()
        {
            // Arrange
            var expected = "< html > test </ html >";
            var response = this.SetupWebResponse(expected);
            this.Mocker.GetMock<IWebRequestService>()
                .Setup(s => s.GetResponseAsync(It.IsAny<WebRequest>()))
                .Returns(Task.FromResult(response));


            // Act
            var actual = this.ClassUnderTest.Scrape("http://www.test.com").Result;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        private WebResponse SetupWebResponse(string responseHtml)
        {
            var expectedBytes = Encoding.UTF8.GetBytes(responseHtml);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(responseStream);
            return response.Object;
        }
    }
}
