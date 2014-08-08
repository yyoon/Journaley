namespace Journaley.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for describing the entry creator information.
    /// </summary>
    public class EntryCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryCreator"/> class.
        /// </summary>
        public EntryCreator()
        {
            this.DeviceAgent = string.Empty;
            this.GenerationDate = string.Empty;
            this.HostName = string.Empty;
            this.OSAgent = string.Empty;
            this.SoftwareAgent = string.Empty;
        }

        /// <summary>
        /// Gets or sets the device agent.
        /// </summary>
        /// <value>
        /// The device agent.
        /// </value>
        public string DeviceAgent { get; set; }

        /// <summary>
        /// Gets or sets the generation date.
        /// </summary>
        /// <value>
        /// The generation date.
        /// </value>
        public string GenerationDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the OS agent.
        /// </summary>
        /// <value>
        /// The OS agent.
        /// </value>
        public string OSAgent { get; set; }

        /// <summary>
        /// Gets or sets the software agent.
        /// </summary>
        /// <value>
        /// The software agent.
        /// </value>
        public string SoftwareAgent { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}", this.DeviceAgent);
        }
    }
}