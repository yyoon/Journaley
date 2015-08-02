namespace Journaley.Forms
{
    partial class WelcomeFormLastScreen
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
            this.pictureBoxLogo = new Journaley.Controls.MouseFallThroughPictureBox();
            this.horizontalSeparator = new System.Windows.Forms.Panel();
            this.labelMainMessage = new System.Windows.Forms.Label();
            this.bottomPanel6Complete = new Journaley.Controls.BorderPanel();
            this.buttonOK = new Journaley.Controls.ColorButton();
            this.labelPanel6Message = new System.Windows.Forms.Label();
            this.panelExtendedTitleBar = new System.Windows.Forms.Panel();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.bottomPanel6Complete.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitlebar
            // 
            this.panelTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.panelTitlebar.Size = new System.Drawing.Size(450, 21);
            // 
            // imageButtonFormClose
            // 
            this.imageButtonFormClose.DownImage = global::Journaley.Properties.Resources.welcome_btn_close_down;
            this.imageButtonFormClose.HoverImage = global::Journaley.Properties.Resources.welcome_btn_close_over;
            this.imageButtonFormClose.Image = global::Journaley.Properties.Resources.welcome_btn_close_norm;
            this.imageButtonFormClose.Location = new System.Drawing.Point(403, 0);
            this.imageButtonFormClose.NormalImage = global::Journaley.Properties.Resources.welcome_btn_close_norm;
            this.imageButtonFormClose.Size = new System.Drawing.Size(47, 21);
            // 
            // imageButtonFormMinimize
            // 
            this.imageButtonFormMinimize.DownImage = global::Journaley.Properties.Resources.welcome_btn_minimize_down;
            this.imageButtonFormMinimize.HoverImage = global::Journaley.Properties.Resources.welcome_btn_minimize_over;
            this.imageButtonFormMinimize.Image = global::Journaley.Properties.Resources.welcome_btn_minimize_norm;
            this.imageButtonFormMinimize.Location = new System.Drawing.Point(311, 0);
            this.imageButtonFormMinimize.NormalImage = global::Journaley.Properties.Resources.welcome_btn_minimize_norm;
            this.imageButtonFormMinimize.Size = new System.Drawing.Size(46, 21);
            // 
            // imageButtonFormMaximize
            // 
            this.imageButtonFormMaximize.Location = new System.Drawing.Point(357, 0);
            this.imageButtonFormMaximize.Size = new System.Drawing.Size(46, 21);
            this.imageButtonFormMaximize.Visible = false;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.bottomPanel6Complete);
            this.panelContent.Controls.Add(this.labelMainMessage);
            this.panelContent.Controls.Add(this.horizontalSeparator);
            this.panelContent.Controls.Add(this.pictureBoxLogo);
            this.panelContent.Controls.Add(this.panelExtendedTitleBar);
            this.panelContent.ForeColor = System.Drawing.Color.Black;
            this.panelContent.Location = new System.Drawing.Point(0, 21);
            this.panelContent.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panelContent.Size = new System.Drawing.Size(450, 579);
            // 
            // pictureBoxFormIcon
            // 
            this.pictureBoxFormIcon.Visible = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::Journaley.Properties.Resources.welcome_journaley;
            this.pictureBoxLogo.Location = new System.Drawing.Point(86, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(278, 212);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // horizontalSeparator
            // 
            this.horizontalSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.horizontalSeparator.Location = new System.Drawing.Point(1, 240);
            this.horizontalSeparator.Name = "horizontalSeparator";
            this.horizontalSeparator.Size = new System.Drawing.Size(448, 1);
            this.horizontalSeparator.TabIndex = 1;
            // 
            // labelMainMessage
            // 
            this.labelMainMessage.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.labelMainMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(249)))));
            this.labelMainMessage.Location = new System.Drawing.Point(10, 294);
            this.labelMainMessage.Name = "labelMainMessage";
            this.labelMainMessage.Size = new System.Drawing.Size(430, 30);
            this.labelMainMessage.TabIndex = 2;
            this.labelMainMessage.Text = "Welcome.";
            this.labelMainMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel6Complete
            // 
            this.bottomPanel6Complete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel6Complete.BorderWidth = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.bottomPanel6Complete.Controls.Add(this.buttonOK);
            this.bottomPanel6Complete.Controls.Add(this.labelPanel6Message);
            this.bottomPanel6Complete.IgnoreSetCursor = false;
            this.bottomPanel6Complete.Location = new System.Drawing.Point(0, 330);
            this.bottomPanel6Complete.Name = "bottomPanel6Complete";
            this.bottomPanel6Complete.Size = new System.Drawing.Size(450, 249);
            this.bottomPanel6Complete.TabIndex = 8;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonOK.BorderColor = System.Drawing.Color.Black;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonOK.DisabledColor = System.Drawing.Color.Empty;
            this.buttonOK.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.buttonOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(228)))));
            this.buttonOK.Location = new System.Drawing.Point(95, 180);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.buttonOK.Selected = false;
            this.buttonOK.SelectedColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedDownColor = System.Drawing.Color.Empty;
            this.buttonOK.SelectedHoverColor = System.Drawing.Color.Empty;
            this.buttonOK.Size = new System.Drawing.Size(260, 42);
            this.buttonOK.TabIndex = 26;
            this.buttonOK.Text = "Start";
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelPanel6Message
            // 
            this.labelPanel6Message.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic);
            this.labelPanel6Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.labelPanel6Message.Location = new System.Drawing.Point(95, 19);
            this.labelPanel6Message.Name = "labelPanel6Message";
            this.labelPanel6Message.Size = new System.Drawing.Size(260, 108);
            this.labelPanel6Message.TabIndex = 5;
            this.labelPanel6Message.Text = "Write what you think.\nClear your mind.\nNever worry.";
            this.labelPanel6Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelExtendedTitleBar
            // 
            this.panelExtendedTitleBar.Location = new System.Drawing.Point(1, 0);
            this.panelExtendedTitleBar.Name = "panelExtendedTitleBar";
            this.panelExtendedTitleBar.Size = new System.Drawing.Size(448, 239);
            this.panelExtendedTitleBar.TabIndex = 10;
            this.panelExtendedTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelExtendedTitleBar_MouseDown);
            this.panelExtendedTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelExtendedTitleBar_MouseMove);
            this.panelExtendedTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelExtendedTitleBar_MouseUp);
            // 
            // WelcomeFormLastScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "WelcomeFormLastScreen";
            this.RealClientSize = new System.Drawing.Size(448, 578);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.WelcomeFormLastScreen_Shown);
            this.panelTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.bottomPanel6Complete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MouseFallThroughPictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel horizontalSeparator;
        private System.Windows.Forms.Label labelMainMessage;
        private Controls.BorderPanel bottomPanel6Complete;
        private System.Windows.Forms.Label labelPanel6Message;
        private Controls.ColorButton buttonOK;
        private System.Windows.Forms.Panel panelExtendedTitleBar;
    }
}