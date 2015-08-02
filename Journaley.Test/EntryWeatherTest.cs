namespace Journaley.Test
{
    using System;
    using System.IO;
    using Journaley.Core.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntryWeatherTest
    {
        [TestMethod]
        public void EntryWeatherLoadTest()
        {
            string path = "51816D511B8E45B9A95A1E6130FADC56.doentry";

            Entry entry = Entry.LoadFromFile(path);

            dynamic weather = entry.Weather;

            Assert.AreEqual("27", weather["Celsius"].Value);
            Assert.AreEqual("Mostly Cloudy", weather["Description"].Value);
            Assert.AreEqual("81", weather["Fahrenheit"].Value);
            Assert.AreEqual("mcloudyn.png", weather["IconName"].Value);
            Assert.AreEqual(1007, weather["Pressure MB"].Value);
            Assert.AreEqual(79, weather["Relative Humidity"].Value);
            Assert.AreEqual("HAMweather", weather["Service"].Value);
            Assert.AreEqual(
                new DateTime(2015, 7, 27, 20, 33, 12, DateTimeKind.Utc),
                weather["Sunrise Date"].Value);
            Assert.AreEqual(
                new DateTime(2015, 7, 28, 10, 45, 34, DateTimeKind.Utc),
                weather["Sunset Date"].Value);
            Assert.AreEqual(6, weather["Visibility KM"].Value);
            Assert.AreEqual(280, weather["Wind Bearing"].Value);
            Assert.AreEqual(27, weather["Wind Chill Celsius"].Value);
            Assert.AreEqual(11, weather["Wind Speed KPH"].Value);
        }

        [TestMethod]
        public void EntryWeatherSaveTest()
        {
            string path = "51816D511B8E45B9A95A1E6130FADC56.doentry";

            Entry entry = Entry.LoadFromFile(path);

            var outputDirectory = @".\Output";
            var outputPath = Path.Combine(outputDirectory, path);

            Directory.CreateDirectory(outputDirectory);
            entry.Save(outputDirectory);

            Assert.IsTrue(File.Exists(outputPath));

            Entry otherEntry = Entry.LoadFromFile(outputPath);

            Assert.AreEqual(entry.Weather, otherEntry.Weather);
        }
    }
}
