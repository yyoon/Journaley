using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Journaley.Core.Models
{
	public class EntryWeather
	{
		public EntryWeather()
		{
			this.Celsius          = string.Empty;
			this.Description      = string.Empty;
			this.Fahrenheit       = string.Empty;
			this.IconName         = string.Empty;
			this.PressureMB       = string.Empty;
			this.RelativeHumidity = string.Empty;
			this.Service          = string.Empty;
			this.SunriseDate      = string.Empty;
			this.SunsetDate       = string.Empty;
			this.VisibilityKM     = string.Empty;
			this.WindBearing      = string.Empty;
			this.WindChillCelsius = string.Empty;
			this.WindSpeedKPH     = string.Empty;           
		}
		public string Celsius          { get; set; }
		public string Description      { get; set; }
		public string Fahrenheit       { get; set; }
		public string IconName         { get; set; }
		public string PressureMB       { get; set; }
		public string RelativeHumidity { get; set; }
		public string Service          { get; set; }
		public string SunriseDate      { get; set; }
		public string SunsetDate       { get; set; }
		public string VisibilityKM     { get; set; }
		public string WindBearing      { get; set; }
		public string WindChillCelsius { get; set; }
		public string WindSpeedKPH     { get; set; }

		public override string ToString()
		{
			return string.Format("{0}° {1}", this.Celsius, this.Description);
		}
	}
}