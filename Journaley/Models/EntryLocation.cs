using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Journaley.Models
{
    public class EntryLocation
    {
        public EntryLocation()
        {
            AdministrativeArea = string.Empty;
            Country            = string.Empty;
            Latitude           = string.Empty;
            Locality           = string.Empty;
            Longitude          = string.Empty;
            PlaceName          = string.Empty;
        }
        public string AdministrativeArea { get; set; }
        public string Country            { get; set; }
        public string Latitude           { get; set; }
        public string Locality           { get; set; }
        public string Longitude          { get; set; }
        public string PlaceName          { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.Locality, this.AdministrativeArea, this.Country);
        }
    }
}
