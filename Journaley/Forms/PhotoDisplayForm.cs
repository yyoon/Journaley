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
    /// Photo Display Form to be displayed when the photo is double-clicked.
    /// </summary>
    public partial class PhotoDisplayForm : BaseJournaleyForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoDisplayForm"/> class.
        /// </summary>
        public PhotoDisplayForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Image Image
        {
            get
            {
                return this.pictureBox.Image;
            }

            set
            {
                this.pictureBox.Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the real client size, which excludes the 1 pixel border as well.
        /// </summary>
        /// <value>
        /// The size of the real client.
        /// </value>
        public override Size RealClientSize
        {
            get
            {
                Size result = base.RealClientSize;
                result.Width -= 2;
                result.Height -= 2;

                return result;
            }

            set
            {
                value.Width += 2;
                value.Height += 2;

                base.RealClientSize = value;
            }
        }
    }
}
