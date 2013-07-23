using DayOneWindowsClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DayOneWindowsClient.Forms;

namespace DayOneWindowsClient.Test
{
    
    
    /// <summary>
    ///This is a test class for MainFormTest and is intended
    ///to contain all MainFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainFormTest
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
        ///A test for GetAllEntriesCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DayOneWindowsClient.exe")]
        public void GetAllEntriesCountTest()
        {
            MainForm_Accessor target = new MainForm_Accessor();
            target.LoadEntries("EntrySet01");

            int expected = 9;
            int actual = target.GetAllEntriesCount();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDaysCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DayOneWindowsClient.exe")]
        public void GetDaysCountTest()
        {
            MainForm_Accessor target = new MainForm_Accessor();
            target.LoadEntries("EntrySet01");

            int expected = 6;
            int actual = target.GetDaysCount();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetThisWeekCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DayOneWindowsClient.exe")]
        public void GetThisWeekCountTest()
        {
            MainForm_Accessor target = new MainForm_Accessor();
            target.LoadEntries("EntrySet01");

            DateTime now = new DateTime(2012, 1, 26, 0, 0, 0, 0, DateTimeKind.Local);

            int expected = 7;
            int actual = target.GetThisWeekCount(now);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTodayCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DayOneWindowsClient.exe")]
        public void GetTodayCountTest()
        {
            MainForm_Accessor target = new MainForm_Accessor();
            target.LoadEntries("EntrySet01");

            DateTime now = new DateTime(2012, 1, 25, 0, 0, 0, 0, DateTimeKind.Local);

            int expected = 2;
            int actual = target.GetTodayCount(now);
            Assert.AreEqual(expected, actual);
        }
    }
}
