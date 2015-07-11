namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The welcome screen which will be shown to the user when Journaley is launched
    /// for the first time
    /// </summary>
    public partial class WelcomeForm : BaseJournaleyForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomeForm"/> class.
        /// </summary>
        public WelcomeForm()
        {
            this.InitializeComponent();
        }
    }
}
