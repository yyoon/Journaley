using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Journaley.Forms
{
    public partial class TagEditForm : Form
    {
        private List<string> assignedTags = new List<string>();

        private List<string> otherTags = new List<string>();

        public List<string> AssignedTags
        {
            get
            {
                return this.assignedTags;
            }
        }

        public List<string> OtherTags
        {
            get
            {
                return this.otherTags;
            }
        }

        public TagEditForm()
        {
            InitializeComponent();
        }

        private void TagEditForm_Load(object sender, EventArgs e)
        {
            this.textTagInput.Select();

            UpdateAssignedTags();
            UpdateOtherTags();
        }

        private void UpdateAssignedTags()
        {
            this.listBoxAssignedTags.Items.Clear();
            this.listBoxAssignedTags.Items.AddRange(this.AssignedTags.ToArray());
        }

        private void UpdateOtherTags()
        {
            this.listBoxOtherTags.Items.Clear();
            this.listBoxOtherTags.Items.AddRange(this.OtherTags.ToArray());
        }

        private void TagEditForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextTagInput_TextChanged(object sender, EventArgs e)
        {
            this.buttonAdd.Enabled = this.textTagInput.Text != string.Empty;
        }

        private void TextTagInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                AddTag();
                e.Handled = true;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddTag();
        }

        private void AddTag()
        {
            AddTag(this.textTagInput.Text);
        }

        private void AddTag(string tag)
        {
            if (!this.AssignedTags.Contains(tag))
            {
                this.AssignedTags.Add(tag);
                this.AssignedTags.Sort();

                UpdateAssignedTags();

                // Check if it's in the other tags list.
                if (this.OtherTags.Contains(tag))
                {
                    this.OtherTags.Remove(tag);

                    UpdateOtherTags();
                }
            }

            // Clear the tag text and focus.
            this.textTagInput.Text = string.Empty;
            this.textTagInput.Select();
        }

        private void ListBoxAssignedTags_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxAssignedTags.IndexFromPoint(e.Location);
            if (0 <= index && index < this.listBoxAssignedTags.Items.Count)
            {
                // Remove from the tags list and put it in the others list.
                string tag = this.listBoxAssignedTags.Items[index] as string;

                this.AssignedTags.Remove(tag);
                UpdateAssignedTags();

                this.OtherTags.Add(tag);
                this.OtherTags.Sort();
                UpdateOtherTags();
            }
        }

        private void ListBoxOtherTags_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxOtherTags.IndexFromPoint(e.Location);
            if (0 <= index && index < this.listBoxOtherTags.Items.Count)
            {
                // Remove from the other tags list and put it in the assigned tags list.
                string tag = this.listBoxOtherTags.Items[index] as string;

                this.OtherTags.Remove(tag);
                UpdateOtherTags();

                this.AssignedTags.Add(tag);
                this.AssignedTags.Sort();
                UpdateAssignedTags();
            }
        }
    }
}
