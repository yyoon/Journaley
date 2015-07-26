namespace Journaley.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for describing the weather information
    /// </summary>
    public class EntryWeather
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryWeather"/> class.
        /// </summary>
        public EntryWeather()
        {
            this.Celsius = string.Empty;
            this.Description = string.Empty;
            this.Fahrenheit = string.Empty;
            this.IconName = string.Empty;
            this.PressureMB = string.Empty;
            this.RelativeHumidity = string.Empty;
            this.Service = string.Empty;
            this.SunriseDate = string.Empty;
            this.SunsetDate = string.Empty;
            this.VisibilityKM = string.Empty;
            this.WindBearing = string.Empty;
            this.WindChillCelsius = string.Empty;
            this.WindSpeedKPH = string.Empty;
        }

        /// <summary>
        /// Gets or sets the temperature value in Celsius.
        /// </summary>
        /// <value>
        /// The Celsius value.
        /// </value>
        public string Celsius { get; set; }

        /// <summary>
        /// Gets or sets the weather description.
        /// </summary>
        /// <value>
        /// The weather description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the temperature value in Fahrenheit.
        /// </summary>
        /// <value>
        /// The Fahrenheit value.
        /// </value>
        public string Fahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the name of the icon.
        /// </summary>
        /// <value>
        /// The name of the icon.
        /// </value>
        public string IconName { get; set; }

        /// <summary>
        /// Gets or sets the pressure in MB.
        /// </summary>
        /// <value>
        /// The pressure in MB.
        /// </value>
        public string PressureMB { get; set; }

        /// <summary>
        /// Gets or sets the relative humidity.
        /// </summary>
        /// <value>
        /// The relative humidity.
        /// </value>
        public string RelativeHumidity { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets the sunrise date.
        /// </summary>
        /// <value>
        /// The sunrise date.
        /// </value>
        public string SunriseDate { get; set; }

        /// <summary>
        /// Gets or sets the sunset date.
        /// </summary>
        /// <value>
        /// The sunset date.
        /// </value>
        public string SunsetDate { get; set; }

        /// <summary>
        /// Gets or sets the visibility in kilometers.
        /// </summary>
        /// <value>
        /// The visibility in kilometers.
        /// </value>
        public string VisibilityKM { get; set; }

        /// <summary>
        /// Gets or sets the wind bearing.
        /// </summary>
        /// <value>
        /// The wind bearing.
        /// </value>
        public string WindBearing { get; set; }

        /// <summary>
        /// Gets or sets the wind chill celsius.
        /// </summary>
        /// <value>
        /// The wind chill celsius.
        /// </value>
        public string WindChillCelsius { get; set; }

        /// <summary>
        /// Gets or sets the wind speed in kilometers per hour.
        /// </summary>
        /// <value>
        /// The wind speed in kilometers per hour.
        /// </value>
        public string WindSpeedKPH { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}° {1}", this.Celsius, this.Description);
        }
    }
}