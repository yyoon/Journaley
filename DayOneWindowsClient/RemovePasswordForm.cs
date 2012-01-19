using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DayOneWindowsClient
{
    public partial class RemovePasswordForm : Form
    {
        public RemovePasswordForm()
        {
            InitializeComponent();
        }

        public string CurrentPassword
        {
            get
            {
                return this.textCurrentPassword.Text;
            }
        }
    }
}
