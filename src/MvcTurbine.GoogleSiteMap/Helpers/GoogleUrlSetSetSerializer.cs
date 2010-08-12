using System.Collections.Generic;
using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public class GoogleUrlSetSetSerializer : IGoogleUrlSetSerializer
    {
        private readonly IGoogleUrlSerializer googleUrlSerializer;

        public GoogleUrlSetSetSerializer(IGoogleUrlSerializer googleUrlSerializer)
        {
            this.googleUrlSerializer = googleUrlSerializer;
        }

        public string Serialize(IEnumerable<GoogleUrl> googleUrls)
        {
            var serializedResults = string.Empty;
            foreach (var url in googleUrls)
                serializedResults += googleUrlSerializer.Serialize(url);

            return string.Format(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<urlset xmlns=""http://www.google.com/schemas/sitemap/0.90"">" +
                                 "{0}" + @"</urlset>", serializedResults);
        }
    }
}