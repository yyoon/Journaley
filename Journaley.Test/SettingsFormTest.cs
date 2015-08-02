namespace Journaley.Test
{
    using System;
    using Journaley.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SettingsFormTest
    {
        [TestMethod]
        public void TestAboutPanelAboveContentPanel()
        {
            SettingsForm settingsForm = new SettingsForm();
            int aboutIndex = -1, contentIndex = -1;
            for (int i = 0; i < settingsForm.Controls.Count; ++i)
            {
                if (settingsForm.Controls[i].Name == "panelAbout")
                {
                    aboutIndex = i;
                }
                else if (settingsForm.Controls[i].Name == "panelContent")
                {
                    contentIndex = i;
                }
            }

            Assert.AreNotEqual(-1, aboutIndex);
            Assert.AreNotEqual(-1, contentIndex);
            Assert.IsTrue(aboutIndex < contentIndex);
        }
    }
}
