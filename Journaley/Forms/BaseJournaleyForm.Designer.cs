namespace Journaley.Forms
{
    partial class BaseJournaleyForm
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
            this.panelTitlebar = new Journaley.Controls.EntryListAreaPanel();
            this.imageButtonFormClose = new Journaley.Controls.ImageButton();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitlebar
            // 
            this.panelTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.panelTitlebar.Controls.Add(this.imageButtonFormClose);
            this.panelTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitlebar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.panelTitlebar.Location = new System.Drawing.Point(0, 0);
            this.panelTitlebar.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitlebar.Name = "panelTitlebar";
            this.panelTitlebar.Size = new System.Drawing.Size(284, 20);
            this.panelTitlebar.TabIndex = 20;
            this.panelTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitlebar_MouseDown);
            this.panelTitlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitlebar_MouseMove);
            this.panelTitlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTitlebar_MouseUp);
            // 
            // imageButtonFormClose
            // 
            this.imageButtonFormClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonFormClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.imageButtonFormClose.DownImage = global::Journaley.Properties.Resources.frame_btn_close_down;
            this.imageButtonFormClose.HoverImage = global::Journaley.Properties.Resources.frame_btn_close_over;
            this.imageButtonFormClose.Image = global::Journaley.Properties.Resources.frame_btn_close_norm;
            this.imageButtonFormClose.Location = new System.Drawing.Point(237, 0);
            this.imageButtonFormClose.Margin = new System.Windows.Forms.Padding(0);
            this.imageButtonFormClose.Name = "imageButtonFormClose";
            this.imageButtonFormClose.NormalImage = global::Journaley.Properties.Resources.frame_btn_close_norm;
            this.imageButtonFormClose.Selected = false;
            this.imageButtonFormClose.SelectedDownImage = null;
            this.imageButtonFormClose.SelectedHoverImage = null;
            this.imageButtonFormClose.SelectedImage = null;
            this.imageButtonFormClose.Size = new System.Drawing.Size(47, 20);
            this.imageButtonFormClose.TabIndex = 1;
            this.imageButtonFormClose.TabStop = false;
            this.imageButtonFormClose.Click += new System.EventHandler(this.ImageButtonFormClose_Click);
            // 
            // BaseJournaleyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panelTitlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseJournaleyForm";
            this.Text = "BaseJournaleyForm";
            this.Deactivate += new System.EventHandler(this.BaseJournaleyForm_Deactivate);
            this.panelTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.EntryListAreaPanel panelTitlebar;
        private Controls.ImageButton imageButtonFormClose;
    }
}