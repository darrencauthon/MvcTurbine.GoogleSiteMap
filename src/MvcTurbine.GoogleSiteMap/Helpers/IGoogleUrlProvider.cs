using System.Collections.Generic;
using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public interface IGoogleUrlProvider
    {
        IEnumerable<GoogleUrl> GetUrls();
    }
}