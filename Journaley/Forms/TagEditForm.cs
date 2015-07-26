namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Used for editing tags of an entry.
    /// </summary>
    public partial class TagEditForm : Form
    {
        /// <summary>
        /// The fore color for buttonAdd when enabled.
        /// </summary>
        private static readonly Color EnabledButtonAddColor = Color.FromArgb(0, 147, 255);

        /// <summary>
        /// The fore color for buttonAdd when disabled.
        /// </summary>
        private static readonly Color DisabledButtonAddColor = SystemColors.GrayText;

        /// <summary>
        /// The list of assigned tags
        /// </summary>
        private List<string> assignedTags = new List<string>();

        /// <summary>
        /// The list of other tags (not assigned to this entry but used in other entries)
        /// </summary>
        private List<string> otherTags = new List<string>();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TagEditForm"/> class.
        /// </summary>
        public TagEditForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the assigned tags.
        /// </summary>
        /// <value>
        /// The assigned tags.
        /// </value>
        public List<string> AssignedTags
        {
            get
            {
                return this.assignedTags;
            }
        }

        /// <summary>
        /// Gets the other tags.
        /// </summary>
        /// <value>
        /// The other tags.
        /// </value>
        public List<string> OtherTags
        {
            get
            {
                return this.otherTags;
            }
        }

        /// <summary>
        /// Handles the Load event of the TagEditForm control.
        /// Sets the focus to the text box, and populate the tag lists.
        /// The client should set the initial list of tags before calling Show() method.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TagEditForm_Load(object sender, EventArgs e)
        {
            this.textTagInput.Select();

            this.UpdateAssignedTags();
            this.UpdateOtherTags();
        }

        /// <summary>
        /// Updates the assigned tags list box, according to the AssignedTags property.
        /// </summary>
        private void UpdateAssignedTags()
        {
            this.listBoxAssignedTags.Items.Clear();
            this.listBoxAssignedTags.Items.AddRange(this.AssignedTags.ToArray());
        }

        /// <summary>
        /// Updates the other tags list box, according to the OtherTags property.
        /// </summary>
        private void UpdateOtherTags()
        {
            this.listBoxOtherTags.Items.Clear();
            this.listBoxOtherTags.Items.AddRange(this.OtherTags.ToArray());
        }

        /// <summary>
        /// Handles the Deactivate event of the TagEditForm control.
        /// This is to close the form when somewhere else than this form is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TagEditForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the TextChanged event of the TextTagInput control.
        /// Checks if the textbox has some text. If so, enables the Add button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextTagInput_TextChanged(object sender, EventArgs e)
        {
            this.buttonAdd.Enabled = this.textTagInput.Text != string.Empty;

            // Update buttonAdd foreColor when enabled or disabled.
            if (this.buttonAdd.Enabled)
            {
                this.buttonAdd.ForeColor = EnabledButtonAddColor;
            }
            else
            {
                this.buttonAdd.ForeColor = DisabledButtonAddColor;
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the TextTagInput control.
        /// Needed for handling the enter key on the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextTagInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.AddTag();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.AddTag();
        }

        /// <summary>
        /// Adds a new tag, which is currently in the textbox.
        /// </summary>
        private void AddTag()
        {
            this.AddTag(this.textTagInput.Text);
        }

        /// <summary>
        /// Adds the given tag to the AssignedTags list.
        /// If the tag was in the OtherTags list, remove it from that list.
        /// Update the list box UIs accordingly.
        /// </summary>
        /// <param name="tag">The tag.</param>
        private void AddTag(string tag)
        {
            if (!this.AssignedTags.Contains(tag))
            {
                this.AssignedTags.Add(tag);
                this.AssignedTags.Sort();

                this.UpdateAssignedTags();

                // Check if it's in the other tags list.
                if (this.OtherTags.Contains(tag))
                {
                    this.OtherTags.Remove(tag);

                    this.UpdateOtherTags();
                }
            }

            // Clear the tag text and focus.
            this.textTagInput.Text = string.Empty;
            this.textTagInput.Select();
        }

        /// <summary>
        /// Handles the MouseClick event of the ListBoxAssignedTags control.
        /// When an item is clicked from the assigned tags list box, move it to the other tags box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void ListBoxAssignedTags_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxAssignedTags.IndexFromPoint(e.Location);
            if (0 <= index && index < this.listBoxAssignedTags.Items.Count)
            {
                // Remove from the tags list and put it in the others list.
                string tag = this.listBoxAssignedTags.Items[index] as string;

                this.AssignedTags.Remove(tag);
                this.UpdateAssignedTags();

                this.OtherTags.Add(tag);
                this.OtherTags.Sort();
                this.UpdateOtherTags();
            }
        }

        /// <summary>
        /// Handles the MouseClick event of the ListBoxOtherTags control.
        /// When an item is clicked from the other tags list box, move it to the assigned tags box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void ListBoxOtherTags_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxOtherTags.IndexFromPoint(e.Location);
            if (0 <= index && index < this.listBoxOtherTags.Items.Count)
            {
                // Remove from the other tags list and put it in the assigned tags list.
                string tag = this.listBoxOtherTags.Items[index] as string;

                this.OtherTags.Remove(tag);
                this.UpdateOtherTags();

                this.AssignedTags.Add(tag);
                this.AssignedTags.Sort();
                this.UpdateAssignedTags();
            }
        }
    }
}
