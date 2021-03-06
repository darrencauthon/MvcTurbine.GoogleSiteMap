﻿using Moq;
using MvcTurbine.GoogleSiteMap.Models;
using MvcTurbine.GoogleSiteMap.Serialization;
using NUnit.Framework;
using Should;

namespace MvcTurbine.GoogleSiteMap.Tests.Serialization
{
    [TestFixture]
    public class GoogleUrlSetSerializerTests
    {
        [Test]
        public void Result_should_start_with_standard_google_site_map_xml()
        {
            var expected = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<urlset xmlns=""http://www.google.com/schemas/sitemap/0.90"">";

            var serializer = new GoogleUrlSetSerializer(new Mock<IGoogleUrlSerializer>().Object);
            var result = serializer.Serialize(new GoogleUrl[] {});
            result.StartsWith(expected).ShouldBeTrue();
        }

        [Test]
        public void Result_ends_with_close_tag()
        {
            var expected = @"</urlset>";

            var serializer = new GoogleUrlSetSerializer(new Mock<IGoogleUrlSerializer>().Object);
            var result = serializer.Serialize(new GoogleUrl[] {});
            result.EndsWith(expected).ShouldBeTrue();
        }

        [Test]
        public void When_passed_one_url_then_include_xml_for_that_url()
        {
            var googleUrl = new GoogleUrl();

            var singleUrlSerializerFake = new Mock<IGoogleUrlSerializer>();
            singleUrlSerializerFake
                .Setup(x => x.Serialize(googleUrl))
                .Returns("RESULTONE");

            var serializer = new GoogleUrlSetSerializer(singleUrlSerializerFake.Object);
            var result = serializer.Serialize(new[] {googleUrl});

            result.Contains("RESULTONE").ShouldBeTrue();
        }

        [Test]
        public void When_passed_two_urls_then_include_xml_for_those_urls()
        {
            var firstUrl = new GoogleUrl();
            var secondUrl = new GoogleUrl();

            var singleUrlSerializerFake = new Mock<IGoogleUrlSerializer>();
            singleUrlSerializerFake
                .Setup(x => x.Serialize(firstUrl))
                .Returns("RESULTONE");
            singleUrlSerializerFake
                .Setup(x => x.Serialize(secondUrl))
                .Returns("RESULTTWO");

            var serializer = new GoogleUrlSetSerializer(singleUrlSerializerFake.Object);
            var result = serializer.Serialize(new[] {firstUrl, secondUrl});

            result.Contains("RESULTONERESULTTWO").ShouldBeTrue();
        }
    }
}