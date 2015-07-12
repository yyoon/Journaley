namespace Journaley.Forms
{
    partial class WelcomeForm
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
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
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
            this.panelContent.Controls.Add(this.panel1);
            this.panelContent.Controls.Add(this.pictureBoxLogo);
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
            this.pictureBoxLogo.Image = global::Journaley.Properties.Resources.welcome_journaley;
            this.pictureBoxLogo.Location = new System.Drawing.Point(86, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(278, 212);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(148)))), ((int)(((byte)(144)))));
            this.panel1.Location = new System.Drawing.Point(1, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 1);
            this.panel1.TabIndex = 1;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "WelcomeForm";
            this.RealClientSize = new System.Drawing.Size(448, 578);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.panelTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panel1;
    }
}