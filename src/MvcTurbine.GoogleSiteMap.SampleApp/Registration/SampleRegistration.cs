using System;
using System.Collections.Generic;
using MvcTurbine.ComponentModel;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.SampleApp.Registration
{
    public class SampleRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IGoogleUrlProvider, ContentUrlProvider>("Content");
            locator.Register<IGoogleUrlProvider, ProductUrlProvider>("Product");
        }
    }

    public class ProductUrlProvider : IGoogleUrlProvider
    {
        public IEnumerable<GoogleUrl> GetUrls()
        {
            return new[]
                       {
                           new GoogleUrl
                               {
                                   Location = "http://localhost/Product1",
                                   ChangeFrequencyOption = ChangeFrequencyOption.Always,
                                   LastModified = DateTime.Now,
                                   Priority = 0.5M,
                               }
                       };
        }
    }

    public class ContentUrlProvider : IGoogleUrlProvider
    {
        public IEnumerable<GoogleUrl> GetUrls()
        {
            return new[] {new GoogleUrl {Location = "http://www.google.com"}};
        }
    }
}