namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Journaley.Core.Models;

    /// <summary>
    /// The welcome UI which will be shown to the user when Journaley is launched for the first time.
    /// This class follows the storyboard described in "WelcomeUI_Storyboard" image file.
    /// </summary>
    public partial class WelcomeFormLastScreen : BaseJournaleyForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomeFormLastScreen"/> class.
        /// </summary>
        public WelcomeFormLastScreen()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the welcome form.
        /// </summary>
        /// <value>
        /// The welcome form.
        /// </value>
        internal WelcomeForm WelcomeForm { get; set; }

        /// <summary>
        /// Handles the Click event of the buttonOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the Shown event of the WelcomeFormLastScreen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WelcomeFormLastScreen_Shown(object sender, EventArgs e)
        {
            if (this.WelcomeForm == null)
            {
                return;
            }

            // For some unknown reason, this last screen form flickers
            // when it tries to close the welcome form immediately.
            // So, here I'm using a Timer object as a workaround.
            Timer timer = new Timer();
            timer.Tick += delegate(object obj, EventArgs args)
            {
                this.WelcomeForm.DialogResult = DialogResult.OK;
                this.WelcomeForm.Close();
            };
            timer.Interval = 50;
            timer.Start();
        }
    }
}
