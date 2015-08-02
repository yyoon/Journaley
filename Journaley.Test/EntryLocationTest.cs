namespace Journaley.Test
{
    using System;
    using System.IO;
    using Journaley.Core.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntryLocationTest
    {
        [TestMethod]
        public void EntryLocationLoadTest()
        {
            string path = "51816D511B8E45B9A95A1E6130FADC56.doentry";

            Entry entry = Entry.LoadFromFile(path);

            dynamic loc = entry.Location;

            Assert.AreEqual("Seoul", loc["Administrative Area"].Value);
            Assert.AreEqual("South Korea", loc["Country"].Value);
            Assert.AreEqual(37.496763073273272m, loc["Latitude"].Value);
            Assert.AreEqual(127.03590421008128m, loc["Longitude"].Value);
            Assert.AreEqual("Gangnamgu", loc["Locality"].Value);
            Assert.AreEqual("744-4 Yeoksamdong", loc["Place Name"].Value);

            Assert.AreEqual(37.496837798641067m, loc["Region"]["Center"]["Latitude"].Value);
            Assert.AreEqual(127.03593650000002m, loc["Region"]["Center"]["Longitude"].Value);
            Assert.AreEqual(70.86290319732386m, loc["Region"]["Radius"].Value);
        }

        [TestMethod]
        public void EntryLocationSaveTest()
        {
            string path = "51816D511B8E45B9A95A1E6130FADC56.doentry";

            Entry entry = Entry.LoadFromFile(path);

            var outputDirectory = @".\Output";
            var outputPath = Path.Combine(outputDirectory, path);

            Directory.CreateDirectory(outputDirectory);
            entry.Save(outputDirectory);

            Assert.IsTrue(File.Exists(outputPath));

            Entry otherEntry = Entry.LoadFromFile(outputPath);

            Assert.AreEqual(entry.Location, otherEntry.Location);
        }
    }
}
