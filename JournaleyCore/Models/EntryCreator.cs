using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Journaley.Core.Models
{
    public class EntryCreator
    {
        public EntryCreator()
        {
            this.DeviceAgent    = string.Empty;
            this.GenerationDate = string.Empty;
            this.HostName       = string.Empty;
            this.OSAgent        = string.Empty;
            this.SoftwareAgent  = string.Empty;     
        }

        public string DeviceAgent    { get; set; }
        public string GenerationDate { get; set; }
        public string HostName       { get; set; }
        public string OSAgent        { get; set; }
        public string SoftwareAgent  { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", this.DeviceAgent);
        }
    }
}