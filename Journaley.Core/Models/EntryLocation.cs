namespace Journaley.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for describing the detailed location where the entry is written.
    /// </summary>
    public class EntryLocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryLocation"/> class.
        /// </summary>
        public EntryLocation()
        {
            this.AdministrativeArea = string.Empty;
            this.Country = string.Empty;
            this.Latitude = string.Empty;
            this.Locality = string.Empty;
            this.Longitude = string.Empty;
            this.PlaceName = string.Empty;
        }

        /// <summary>
        /// Gets or sets the administrative area.
        /// </summary>
        /// <value>
        /// The administrative area.
        /// </value>
        public string AdministrativeArea { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the locality.
        /// </summary>
        /// <value>
        /// The locality.
        /// </value>
        public string Locality { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public string Longitude { get; set; }

        /// <summary>
        /// Gets or sets the name of the place.
        /// </summary>
        /// <value>
        /// The name of the place.
        /// </value>
        public string PlaceName { get; set; }

        public CircularRegion Region { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.Locality, this.AdministrativeArea, this.Country);
        }

        public class GeoLocation
        {
            public decimal Longitude { get; set; }
            public decimal Latitude { get; set; }
        }

        public class CircularRegion
        {
            public GeoLocation Center { get; set; }
            public decimal Radius { get; set; }
        }
    }
}
