using System.Web.Mvc;
using MvcTurbine.GoogleSiteMap.Helpers;

namespace MvcTurbine.GoogleSiteMap.Controllers
{
    public class GoogleSiteMapController : Controller
    {
        private readonly IGoogleUrlSerializer googleUrlSerializer;
        private readonly IGoogleUrlProvider googleUrlProvider;

        public GoogleSiteMapController(IGoogleUrlSerializer googleUrlSerializer, IGoogleUrlProvider googleUrlProvider)
        {
            this.googleUrlSerializer = googleUrlSerializer;
            this.googleUrlProvider = googleUrlProvider;
        }

        public string Index()
        {
            var googleUrls = googleUrlProvider.GetUrls();
            return googleUrlSerializer.Serialize(googleUrls);
        }
    }
}