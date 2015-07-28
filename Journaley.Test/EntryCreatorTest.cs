namespace Journaley.Test
{
    using System;
    using System.IO;
    using Journaley.Core.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntryCreatorTest
    {
        [TestMethod]
        public void EntryCreatorLoadTest()
        {
            string path = "51816D511B8E45B9A95A1E6130FADC56.doentry";

            Entry entry = Entry.LoadFromFile(path);

            dynamic creator = entry.Creator;

            Assert.AreEqual("iPhone/iPhone7,2", creator["Device Agent"].Value);
            Assert.AreEqual(
                new DateTime(2015, 7, 28, 12, 7, 20, DateTimeKind.Utc),
                creator["Generation Date"].Value);
            Assert.AreEqual("nullstein-iPhone", creator["Host Name"].Value);
            Assert.AreEqual("iOS/8.4", creator["OS Agent"].Value);
            Assert.AreEqual("Day One iOS/1.17.1", creator["Software Agent"].Value);
        }

        [TestMethod]
        public void EntryCreatorSaveTest()
        {
            string path = "51816D511B8E45B9A95A1E6130FADC56.doentry";

            Entry entry = Entry.LoadFromFile(path);

            var outputDirectory = @".\Output";
            var outputPath = Path.Combine(outputDirectory, path);

            Directory.CreateDirectory(outputDirectory);
            entry.Save(outputDirectory);

            Assert.IsTrue(File.Exists(outputPath));

            Entry otherEntry = Entry.LoadFromFile(outputPath);

            Assert.AreEqual(entry.Creator, otherEntry.Creator);
        }
    }
}
