using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public class GoogleUrlSerializer : IGoogleUrlSerializer
    {
        public string Serialize(GoogleUrl googleUrl)
        {
            var xml = string.Format(@"<loc>{0}</loc>", googleUrl.Location);

            if (googleUrl.Priority != null)
                xml += string.Format(@"<priority>{0}</priority>", googleUrl.Priority);

            if (googleUrl.ChangeFrequencyOption != ChangeFrequencyOption.NA)
                xml += string.Format("<changefreq>{0}</changefreq>", googleUrl.ChangeFrequencyOption.ToString().ToLower());

            return string.Format(@"<url>{0}</url>", xml);
        }
    }
}