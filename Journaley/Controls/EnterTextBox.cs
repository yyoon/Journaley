namespace Journaley.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// A custom text box control that takes Enter key as an input key.
    /// </summary>
    public class EnterTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                return true;
            }

            return base.IsInputKey(keyData);
        }
    }
}
