using System.Collections.Generic;
using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public interface IGoogleUrlSerializer
    {
        string Serialize(IEnumerable<GoogleUrl> googleUrls);
    }
}