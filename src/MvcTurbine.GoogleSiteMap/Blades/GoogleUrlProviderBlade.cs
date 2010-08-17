using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;
using MvcTurbine.GoogleSiteMap.Helpers;

namespace MvcTurbine.GoogleSiteMap.Blades
{
    public class GoogleUrlProviderBlade : Blade, ISupportAutoRegistration
    {
        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            registrationList.Add(ComponentModel.Registration.Simple<IGoogleUrlProvider>());
        }

        public override void Spin(IRotorContext context)
        {
        }
    }
}