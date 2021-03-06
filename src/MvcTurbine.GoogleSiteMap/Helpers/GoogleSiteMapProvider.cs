﻿using System.Collections.Generic;
using System.Linq;
using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public interface IGoogleSiteMapProvider
    {
        IEnumerable<GoogleUrl> GetUrls();
    }

    public class GoogleSiteMapProvider : IGoogleSiteMapProvider
    {
        private readonly IGoogleUrlProvider[] googleUrlProviders;

        public GoogleSiteMapProvider(IGoogleUrlProvider[] googleUrlProviders)
        {
            this.googleUrlProviders = googleUrlProviders;
        }

        public IEnumerable<GoogleUrl> GetUrls()
        {
            if (googleUrlProviders.Any() == false)
                return new GoogleUrl[] {};

            var list = new List<GoogleUrl>();

            foreach (var googleUrlProvider in googleUrlProviders)
                list.AddRange(googleUrlProvider.GetUrls());

            return list;
        }
    }
}