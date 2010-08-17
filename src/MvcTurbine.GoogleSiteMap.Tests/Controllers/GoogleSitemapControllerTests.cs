using Moq;
using MvcTurbine.GoogleSiteMap.Controllers;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Models;
using MvcTurbine.GoogleSiteMap.Serialization;
using NUnit.Framework;
using Should;

namespace MvcTurbine.GoogleSiteMap.Tests.Controllers
{
    [TestFixture]
    public class GoogleSiteMapControllerTests
    {
        [Test]
        public void Index_returns_serialized_result_from_sitemap_url_provider()
        {
            var googleUrls = new GoogleUrl[] {};

            var googleUrlProvider = new Mock<IGoogleUrlProvider>();
            googleUrlProvider.Setup(x => x.GetUrls())
                .Returns(googleUrls);

            var serializerFake = new Mock<IGoogleUrlSetSerializer>();
            serializerFake.Setup(x => x.Serialize(googleUrls))
                .Returns("EXPECTED");

            var controller = new GoogleSiteMapController(serializerFake.Object, googleUrlProvider.Object);
            var result = controller.Index();

            result.ShouldEqual("EXPECTED");
        }
    }
}