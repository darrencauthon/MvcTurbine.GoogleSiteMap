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
            locator.Register<IGoogleUrlProvider, GoogleSiteMapProvider>();
            locator.Register<IGoogleUrlSetSerializer, TempGoogleUrlSetSerializer>();
        }
    }

    public class TempGoogleUrlSetSerializer : IGoogleUrlSetSerializer
    {
        public string Serialize(IEnumerable<GoogleUrl> googleUrls)
        {
            return "X";
        }
    }
}