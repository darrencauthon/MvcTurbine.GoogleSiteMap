using System.Linq;
using Moq;
using MvcTurbine.GoogleSiteMap.Helpers;
using MvcTurbine.GoogleSiteMap.Models;
using NUnit.Framework;
using Should;

namespace MvcTurbine.GoogleSiteMap.Tests.Helpers
{
    [TestFixture]
    public class GoogleSiteMapProviderTests
    {
        [Test]
        public void GetUrls_should_return_urls_from_provider_that_is_passed_in()
        {
            var expected = new[] {new GoogleUrl(), new GoogleUrl()};

            var providerFake = new Mock<IGoogleUrlProvider>();
            providerFake.Setup(x => x.GetUrls())
                .Returns(expected);

            var provider = new GoogleSiteMapProvider(new[] {providerFake.Object});
            var results = provider.GetUrls();

            results.Count().ShouldEqual(2);
            results.ToList().ForEach(url => expected.Contains(url).ShouldBeTrue());
        }

        [Test]
        public void GetUrls_should_return_empty_set_when_passed_no_providers()
        {
            var provider = new GoogleSiteMapProvider(new IGoogleUrlProvider[] {});
            var results = provider.GetUrls();

            results.Count().ShouldEqual(0);
        }

        [Test]
        public void GetUrls_should_return_results_from_two_providers()
        {
            var firstSet = new[] {new GoogleUrl(), new GoogleUrl()};
            var firstProviderFake = new Mock<IGoogleUrlProvider>();
            firstProviderFake.Setup(x => x.GetUrls())
                .Returns(firstSet);

            var secondSet = new[] {new GoogleUrl()};
            var secondProviderFake = new Mock<IGoogleUrlProvider>();
            secondProviderFake.Setup(x => x.GetUrls())
                .Returns(secondSet);

            var provider = new GoogleSiteMapProvider(new[] {firstProviderFake.Object, secondProviderFake.Object});
            var results = provider.GetUrls();

            results.Count().ShouldEqual(3);

            results.ToList()
                .ForEach(url => (firstSet.Contains(url) ||
                                 secondSet.Contains(url)).ShouldBeTrue());
        }
    }
}