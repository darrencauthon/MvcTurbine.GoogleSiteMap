using System.Web.Mvc;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Serialization;

namespace MvcTurbine.GoogleSiteMap.Controllers
{
    public class GoogleSiteMapController : Controller
    {
        private readonly IGoogleUrlSetSerializer googleUrlSetSerializer;
        private readonly IGoogleUrlProvider googleUrlProvider;

        public GoogleSiteMapController(IGoogleUrlSetSerializer googleUrlSetSerializer, IGoogleUrlProvider googleUrlProvider)
        {
            this.googleUrlSetSerializer = googleUrlSetSerializer;
            this.googleUrlProvider = googleUrlProvider;
        }

        public string Index()
        {
            var googleUrls = googleUrlProvider.GetUrls();
            return googleUrlSetSerializer.Serialize(googleUrls);
        }
    }
}