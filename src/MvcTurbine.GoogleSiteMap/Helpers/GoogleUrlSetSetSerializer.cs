using System.Collections.Generic;
using System.Xml.Linq;
using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public interface IGoogleUrlSetSerializer
    {
        string Serialize(IEnumerable<GoogleUrl> googleUrls);
    }

    public class FormattedGoogleUrlSetSetSerializer : GoogleUrlSetSetSerializer
    {
        public FormattedGoogleUrlSetSetSerializer(IGoogleUrlSerializer googleUrlSerializer)
            : base(googleUrlSerializer)
        {
        }

        public override string Serialize(IEnumerable<GoogleUrl> googleUrls)
        {
            var xml = base.Serialize(googleUrls);
            var formattedXml = XDocument.Parse(xml).ToString();
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" + formattedXml;
        }
    }

    public class GoogleUrlSetSetSerializer : IGoogleUrlSetSerializer
    {
        private readonly IGoogleUrlSerializer googleUrlSerializer;

        public GoogleUrlSetSetSerializer(IGoogleUrlSerializer googleUrlSerializer)
        {
            this.googleUrlSerializer = googleUrlSerializer;
        }

        public virtual string Serialize(IEnumerable<GoogleUrl> googleUrls)
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