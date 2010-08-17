using System.Web.Mvc;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Serialization;

namespace MvcTurbine.GoogleSiteMap.Controllers
{
    public class GoogleSiteMapController : Controller
    {
        private readonly IGoogleUrlSetSerializer googleUrlSetSerializer;
        private readonly IGoogleSiteMapProvider googleSiteMapProvider;

        public GoogleSiteMapController(IGoogleUrlSetSerializer googleUrlSetSerializer,
                                       IGoogleSiteMapProvider googleSiteMapProvider)
        {
            this.googleUrlSetSerializer = googleUrlSetSerializer;
            this.googleSiteMapProvider = googleSiteMapProvider;
        }

        public string Index()
        {
            var googleUrls = googleSiteMapProvider.GetUrls();
            return googleUrlSetSerializer.Serialize(googleUrls);
        }
    }
}