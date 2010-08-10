using System.Collections.Generic;
using MvcTurbine.ComponentModel;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Registration
{
    public class Registration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IGoogleUrlProvider, TempGoogleUrlProvider>();
            locator.Register<IGoogleUrlSerializer, TempGoogleUrlSerializer>();
        }
    }

    public class TempGoogleUrlSerializer : IGoogleUrlSerializer
    {
        public string Serialize(IEnumerable<GoogleUrl> googleUrls)
        {
            return "X";
        }
    }

    public class TempGoogleUrlProvider : IGoogleUrlProvider
    {
        public IEnumerable<GoogleUrl> GetUrls()
        {
            return new GoogleUrl[] {};
        }
    }
}