using System.Web.Mvc;
using System.Web.Routing;
using MvcTurbine.Routing;

namespace MvcTurbine.GoogleSiteMap.Routing
{
    public class SiteMapRouting : IRouteRegistrator
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute("SiteMap",
                            "sitemap.xml",
                            new
                                {
                                    controller = "GoogleSiteMap",
                                    action = "Index",
                                    id = UrlParameter.Optional
                                });
        }
    }
}