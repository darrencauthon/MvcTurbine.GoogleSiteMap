﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Models;
using NUnit.Framework;
using Should;

namespace MvcTurbine.GoogleSiteMap.Tests.Helpers
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

    }
}