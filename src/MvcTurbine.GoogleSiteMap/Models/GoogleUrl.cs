using System;
using MvcTurbine.GoogleSiteMap.Helpers;

namespace MvcTurbine.GoogleSiteMap.Models
{
    public class GoogleUrl
    {
        public string Location { get; set; }

        public decimal? Priority { get; set; }

        public ChangeFrequencyOption ChangeFrequencyOption { get; set; }

        public DateTime? LastModified { get; set; }
    }
}