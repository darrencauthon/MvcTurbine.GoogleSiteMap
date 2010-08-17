using MvcTurbine.ComponentModel;
using MvcTurbine.GoogleSiteMap.Helpers;

namespace MvcTurbine.GoogleSiteMap.Registration
{
    public class Registration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IGoogleUrlProvider, GoogleSiteMapProvider>();
            locator.Register<IGoogleUrlSetSerializer, FormattedGoogleUrlSetSerializer>();
            locator.Register<IGoogleUrlSerializer, GoogleUrlSerializer>();
        }
    }
}