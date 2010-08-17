using System;
using MvcTurbine.GoogleSiteMap.Models;
using MvcTurbine.GoogleSiteMap.Serialization;
using NUnit.Framework;
using Should;

namespace MvcTurbine.GoogleSiteMap.Tests.Serialization
{
    [TestFixture]
    public class GoogleUrlSerializerTests
    {
        [Test]
        public void Begins_with_url_begin_tag()
        {
            var expected = @"<url>";

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(new GoogleUrl());

            result.StartsWith(expected).ShouldBeTrue();
        }

        [Test]
        public void Ends_with_close_tag()
        {
            var expected = @"</url>";

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(new GoogleUrl());

            result.EndsWith(expected).ShouldBeTrue();
        }

        [Test]
        public void Contains_the_loc_tag_with_the_location()
        {
            var expected = @"<loc>XYZ</loc>";

            var googleUrl = new GoogleUrl
                                {
                                    Location = "XYZ"
                                };

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(googleUrl);

            result.Contains(expected).ShouldBeTrue();
        }

        [Test]
        public void Contains_the_priority_with_the_priority_of_the_url()
        {
            var expected = @"<priority>0.7</priority>";
            var googleUrl = new GoogleUrl
                                {
                                    Priority = 0.7M
                                };

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(googleUrl);

            result.Contains(expected).ShouldBeTrue();
        }

        [Test]
        public void Does_not_contain_a_priority_tag_if_the_priority_is_null()
        {
            var expected = @"<priority";
            var googleUrl = new GoogleUrl
                                {
                                    Priority = null
                                };

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(googleUrl);

            result.Contains(expected).ShouldBeFalse();
        }

        [Test]
        public void Includes_a_changefreq_tag_with_the_lower_case_version_of_ChangeFrequency()
        {
            var expected = @"<changefreq>always</changefreq>";
            var googleUrl = new GoogleUrl
                                {
                                    ChangeFrequencyOption = ChangeFrequencyOption.Always
                                };

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(googleUrl);

            result.Contains(expected).ShouldBeTrue();
        }

        [Test]
        public void Does_not_include_a_change_freq_tag_when_the_change_frequency_is_NA()
        {
            var expected = @"<changefreq";
            var googleUrl = new GoogleUrl
                                {
                                    ChangeFrequencyOption = ChangeFrequencyOption.NA
                                };

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(googleUrl);

            result.Contains(expected).ShouldBeFalse();
        }

        [Test]
        public void Includes_a_lastmod_tag_with_the_universal_version_of_LastModified()
        {
            var expected = "<lastmod>2010-12-26T05:12:57Z</lastmod>";

            var googleUrl = new GoogleUrl
                                {
                                    LastModified = new DateTime(2010, 12, 25, 23, 12, 57, 3)
                                };

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(googleUrl);

            result.Contains(expected).ShouldBeTrue();
        }

        [Test]
        public void Does_not_include_a_last_mod_tag_when_the_LastModified_is_null()
        {
            var expected = "<lastmod";

            var googleUrl = new GoogleUrl
                                {
                                    LastModified = null
                                };

            var serializer = new GoogleUrlSerializer();
            var result = serializer.Serialize(googleUrl);

            result.Contains(expected).ShouldBeFalse();
        }
    }
}