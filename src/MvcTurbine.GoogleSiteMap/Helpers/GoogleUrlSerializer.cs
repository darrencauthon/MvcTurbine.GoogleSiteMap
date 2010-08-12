using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public class GoogleUrlSerializer : IGoogleUrlSerializer
    {
        public string Serialize(GoogleUrl googleUrl)
        {
            var xml = string.Format(@"<loc>{0}</loc>", googleUrl.Location);
            return string.Format(@"<url>{0}</url>", xml);
        }
    }
}