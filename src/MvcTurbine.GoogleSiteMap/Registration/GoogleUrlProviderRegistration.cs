using System;
using System.Linq;
using MvcTurbine.ComponentModel;
using MvcTurbine.GoogleSiteMap.Helpers;

namespace MvcTurbine.GoogleSiteMap.Registration
{
    public class GoogleUrlProviderRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            var googleUrlProviderType = typeof (IGoogleUrlProvider);
            AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x != googleUrlProviderType.Assembly)
                .ToList()
                .ForEach(assembly => assembly.GetTypes()
                                         .Where(x => x.IsAbstract == false && x.IsInterface == false)
                                         .Where(x => x.GetInterfaces() != null && x.GetInterfaces().Contains(googleUrlProviderType))
                                         .ToList()
                                         .ForEach(type =>
                                                      {
                                                          locator.Register(googleUrlProviderType, type);
                                                      }));
        }
    }
}