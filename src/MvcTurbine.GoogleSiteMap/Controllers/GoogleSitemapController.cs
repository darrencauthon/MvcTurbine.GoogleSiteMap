using MvcTurbine.GoogleSiteMap.Helpers;

namespace MvcTurbine.GoogleSiteMap.Controllers
{
    public class GoogleSitemapController
    {
        private readonly IGoogleUrlSerializer googleUrlSerializer;
        private readonly IGoogleUrlProvider googleUrlProvider;

        public GoogleSitemapController(IGoogleUrlSerializer googleUrlSerializer, IGoogleUrlProvider googleUrlProvider)
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