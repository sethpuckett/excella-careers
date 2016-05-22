using System.IO;
using System.Linq;
using System.Reflection;
using AutoMoq;
using ExcellaCareers.Services.Impl;
using NUnit.Framework;

namespace ExcellaCareers.Tests.Services
{
    [TestFixture]
    public class CareerHtmlParserTests
    {
        private CareerHtmlParser ClassUnderTest { get; set; }

        private AutoMoqer Mocker { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Mocker = new AutoMoqer();
            this.ClassUnderTest = this.Mocker.Create<CareerHtmlParser>();
        }

        [Test]
        public void ParseJobList_GivenValidHtml_ExpectJobList()
        {
            // Arrange
            var html = GetJobListHtml();

            // Act
            var jobs = this.ClassUnderTest.ParseJobList(html).ToList();

            // Assert
            Assert.That(jobs, Is.Not.Null);
            Assert.That(jobs, Is.Not.Empty);
        }

        private string GetJobListHtml()
        {
            return this.GetFileContents("joblist.html");
        }

        private string GetFileContents(string filename)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resource = $"ExcellaCareers.Tests.Resources.{filename}";
            using (var stream = asm.GetManifestResourceStream(resource))
            {
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}
