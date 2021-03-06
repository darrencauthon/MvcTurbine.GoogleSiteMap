﻿using MvcTurbine.ComponentModel;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Serialization;

namespace MvcTurbine.GoogleSiteMap.Registration
{
    public class Registration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IGoogleSiteMapProvider, GoogleSiteMapProvider>();
            locator.Register<IGoogleUrlSetSerializer, FormattedGoogleUrlSetSerializer>();
            locator.Register<IGoogleUrlSerializer, GoogleUrlSerializer>();
        }
    }
}