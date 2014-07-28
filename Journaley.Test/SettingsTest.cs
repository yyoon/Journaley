using Journaley;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Journaley.Core.Models;
using System.Xml.Serialization;
using System.Text;

namespace Journaley.Test
{
    
    
    /// <summary>
    ///This is a test class for SettingsTest and is intended
    ///to contain all SettingsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SettingsTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetSettingsFile
        ///</summary>
        [TestMethod()]
        public void GetSettingsFileTest()
        {
            string path = Path.GetTempFileName();
            Settings actual = Settings.GetSettingsFile(path);
            Assert.IsNull(actual);
        }

        /// <summary>
        ///A test for GetSettingsFile
        ///</summary>
        [TestMethod()]
        public void GetSettingsFileTest1()
        {
            string path = "test1.settings";
            Settings expected = new Settings();
            expected.Password = "password";
            expected.DayOneFolderPath = ".";
            Settings actual;
            actual = Settings.GetSettingsFile(path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            string path = "test.settings";

            Settings target = new Settings();
            Assert.IsFalse(target.Save(path));

            target.DayOneFolderPath = ".";
            Assert.IsTrue(target.Save(path));

            Settings loaded = Settings.GetSettingsFile(path);
            Assert.AreEqual(target, loaded);
        }

        /// <summary>
        ///A test for ComputeMD5Hash
        ///</summary>
        [TestMethod()]
        public void ComputeMD5HashTest()
        {
            Settings target = new Settings();
            string expected = "5f4dcc3b5aa765d61d8327deb882cf99";
            string actual = target.ComputeMD5Hash("password");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for VerifyPassword
        ///</summary>
        [TestMethod()]
        public void VerifyPasswordTest()
        {
            Settings target = new Settings();
            target.Password = "password";
            Assert.IsTrue(target.VerifyPassword("password"));
            Assert.IsFalse(target.VerifyPassword("wrong-password"));
        }

        /*
        [TestMethod]
        public void StripEntriesTest()
        {
            string path = "beforeRemovingEntries.settings";

            Settings expected = new Settings();
            expected.PasswordHash = "5f4dcc3b5aa765d61d8327deb882cf99";
            expected.DayOneFolderPath = @"P:\앱\Day One\Journal.dayone";

            Settings loaded = Settings.GetSettingsFile(path);
            Assert.AreEqual(expected, loaded);

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                loaded = serializer.Deserialize(sr) as Settings;

                Assert.AreEqual(expected, loaded);
            }
        }
        */
    }
}
