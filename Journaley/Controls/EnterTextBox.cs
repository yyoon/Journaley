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
        /// <summary>
        /// Determines whether the specified key is an input key or a special key that requires
        /// preprocessing.
        /// </summary>
        /// <param name="keyData">One of the key's values.</param>
        /// <returns>
        /// true if the specified key is an input key; otherwise, false.
        /// </returns>
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
