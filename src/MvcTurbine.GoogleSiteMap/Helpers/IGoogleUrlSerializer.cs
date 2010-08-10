using MvcTurbine.GoogleSiteMap.Models;

namespace MvcTurbine.GoogleSiteMap.Helpers
{
    public interface IGoogleUrlSerializer
    {
        string Serialize(GoogleUrl googleUrl);
    }
}