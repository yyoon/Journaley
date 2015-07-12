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
        /// List of all the bottom panels
        /// </summary>
        private List<Panel> bottomPanels;

        /// <summary>
        /// The sub-messages to be shown for each bottom panel.
        /// </summary>
        private Dictionary<int, string> panelMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomeForm"/> class.
        /// </summary>
        public WelcomeForm()
        {
            this.InitializeComponent();

            this.bottomPanels = new List<Panel>();
            this.bottomPanels.Add(this.bottomPanel1Init);
            this.bottomPanels.Add(this.bottomPanel2StartNewJournal);
            this.bottomPanels.Add(this.bottomPanel3LocationSelected);
            this.bottomPanels.Add(this.bottomPanel4PasswordSetting);
            this.bottomPanels.Add(this.bottomPanel5ImportJournal);
            this.bottomPanels.Add(this.bottomPanel6Complete);

            this.panelMessages = new Dictionary<int, string>();
            this.panelMessages.Add(2, "Okay.");
            this.panelMessages.Add(3, "Great!");
            this.panelMessages.Add(4, "Make sure not to forget it!");
            this.panelMessages.Add(5, "Okay.");
            this.panelMessages.Add(6, "Welcome.");

            this.ShowBottomPanel(1);
        }

        /// <summary>
        /// Shows the bottom panel.
        /// </summary>
        /// <param name="panelIndex">Index of the panel (1 - 6).</param>
        /// <exception cref="System.IndexOutOfRangeException">thrown when the given index is out of range.</exception>
        private void ShowBottomPanel(int panelIndex)
        {
            if (panelIndex < 1 || panelIndex > this.bottomPanels.Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (panelIndex == 1)
            {
                this.ShowGreetings();
            }
            else
            {
                this.labelMainMessage.Text = this.panelMessages[panelIndex];
            }

            for (int i = 0; i < this.bottomPanels.Count; ++i)
            {
                this.bottomPanels[i].Visible = i + 1 == panelIndex;
            }
        }

        /// <summary>
        /// Shows the greetings message depending on the current time.
        /// [00:00, 12:00) : Good morning.
        /// [12:00, 17:00) : Good afternoon.
        /// [17:00, 24:00) : Good evening.
        /// </summary>
        private void ShowGreetings()
        {
            DateTime now = DateTime.Now;

            if (0 <= now.Hour && now.Hour < 12)
            {
                this.labelMainMessage.Text = "Good morning.";
            }
            else if (now.Hour < 17)
            {
                this.labelMainMessage.Text = "Good afternoon.";
            }
            else
            {
                this.labelMainMessage.Text = "Good evening.";
            }
        }
    }
}
