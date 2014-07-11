using Journaley.Core.Models;
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
    public partial class LocationForm : Form
    {
        public LocationForm(EntryLocation location)
        {
            InitializeComponent();
            labelAddress.Text = location.ToString();
        }

        private void LocationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
