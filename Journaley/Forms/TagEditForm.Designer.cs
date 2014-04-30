namespace Journaley.Forms
{
    partial class TagEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAssignedTags = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxOtherTags = new System.Windows.Forms.ListBox();
            this.textTagInput = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(-1, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Tags (Click to Remove)";
            // 
            // listBoxAssignedTags
            // 
            this.listBoxAssignedTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAssignedTags.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxAssignedTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxAssignedTags.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAssignedTags.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.listBoxAssignedTags.FormattingEnabled = true;
            this.listBoxAssignedTags.ItemHeight = 15;
            this.listBoxAssignedTags.Location = new System.Drawing.Point(2, 41);
            this.listBoxAssignedTags.Name = "listBoxAssignedTags";
            this.listBoxAssignedTags.Size = new System.Drawing.Size(219, 75);
            this.listBoxAssignedTags.TabIndex = 1;
            this.listBoxAssignedTags.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxAssignedTags_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(-1, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Previous Tags (Click to Add)";
            // 
            // listBoxOtherTags
            // 
            this.listBoxOtherTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOtherTags.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxOtherTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxOtherTags.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOtherTags.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listBoxOtherTags.FormattingEnabled = true;
            this.listBoxOtherTags.ItemHeight = 15;
            this.listBoxOtherTags.Location = new System.Drawing.Point(2, 177);
            this.listBoxOtherTags.Name = "listBoxOtherTags";
            this.listBoxOtherTags.Size = new System.Drawing.Size(219, 120);
            this.listBoxOtherTags.TabIndex = 5;
            this.listBoxOtherTags.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxOtherTags_MouseClick);
            // 
            // textTagInput
            // 
            this.textTagInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTagInput.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textTagInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTagInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTagInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.textTagInput.Location = new System.Drawing.Point(2, 121);
            this.textTagInput.Name = "textTagInput";
            this.textTagInput.Size = new System.Drawing.Size(153, 23);
            this.textTagInput.TabIndex = 2;
            this.textTagInput.TextChanged += new System.EventHandler(this.TextTagInput_TextChanged);
            this.textTagInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextTagInput_KeyPress);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(153, 120);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 24);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // TagEditForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(46)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(223, 319);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textTagInput);
            this.Controls.Add(this.listBoxOtherTags);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAssignedTags);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TagEditForm";
            this.Deactivate += new System.EventHandler(this.TagEditForm_Deactivate);
            this.Load += new System.EventHandler(this.TagEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAssignedTags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxOtherTags;
        private System.Windows.Forms.TextBox textTagInput;
        private System.Windows.Forms.Button buttonAdd;
    }
}