namespace Journaley.Models
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// A class containing various settings.
    /// Uses .NET serialization for storing/restoring the data.
    /// </summary>
    [Serializable]
    public class Settings : IEquatable<Settings>, IPasswordVerifier
    {
        /// <summary>
        /// The settings folder
        /// </summary>
        private static readonly string SettingsFolder = "Journaley";

        /// <summary>
        /// The settings filename
        /// </summary>
        private static readonly string SettingsFilename = "Journaley.settings";

        /// <summary>
        /// The backing field for the MD5Instance property.
        /// </summary>
        private static MD5 md5 = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            this.PasswordHash = null;
            this.DayOneFolderPath = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        /// <param name="other">The other settings object from which the settings will be copied.</param>
        public Settings(Settings other)
        {
            this.PasswordHash = other.PasswordHash;
            this.DayOneFolderPath = other.DayOneFolderPath;
        }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the day one folder path.
        /// </summary>
        /// <value>
        /// The day one folder path.
        /// </value>
        public string DayOneFolderPath { get; set; }

        /// <summary>
        /// Sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            set
            {
                this.PasswordHash = this.ComputeMD5Hash(value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has password.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has password; otherwise, <c>false</c>.
        /// </value>
        public bool HasPassword
        {
            get
            {
                return this.PasswordHash != null;
            }
        }

        /// <summary>
        /// Gets the MD5 instance.
        /// </summary>
        /// <value>
        /// The MD5 instance.
        /// </value>
        private static MD5 MD5Instance
        {
            get
            {
                if (md5 == null)
                {
                    md5 = MD5.Create();
                }

                return md5;
            }
        }

        /// <summary>
        /// Gets the settings file using the default settings file path.
        /// </summary>
        /// <returns>The settings object read from the settings file</returns>
        public static Settings GetSettingsFile()
        {
            return GetSettingsFile(GetSettingsFilePath());
        }

        /// <summary>
        /// Gets the settings file with the given path to the settings file.
        /// </summary>
        /// <param name="path">The path to the settings file.</param>
        /// <returns>The settings object read from the given path.</returns>
        public static Settings GetSettingsFile(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    Settings settings = serializer.Deserialize(sr) as Settings;

                    if (!Directory.Exists(settings.DayOneFolderPath))
                    {
                        return null;
                    }

                    return settings;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Saves this instance to the default settings file path.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if succeeded; otherwise, <c>false</c>.
        /// </returns>
        public bool Save()
        {
            return this.Save(GetSettingsFilePath());
        }

        /// <summary>
        /// Saves this instance to the specified path.
        /// </summary>
        /// <param name="path">The path to the settings file.</param>
        /// <returns>
        ///   <c>true</c> if succeeded; otherwise, <c>false</c>.
        /// </returns>
        public bool Save(string path)
        {
            if (!Directory.Exists(this.DayOneFolderPath))
            {
                return false;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(sw, this);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Computes the MD5 hash of the given input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A string representing the MD5 hash of the given input</returns>
        public string ComputeMD5Hash(string input)
        {
            byte[] data = MD5Instance.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; ++i)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Verifies if the given password matches with the known password.
        /// </summary>
        /// <param name="inputPassword">The input password.</param>
        /// <returns>
        ///   <c>true</c> if the given password matches; otherwise, <c>false</c>.
        /// </returns>
        public bool VerifyPassword(string inputPassword)
        {
            string inputHash = this.ComputeMD5Hash(inputPassword);
            return string.Equals(this.PasswordHash, inputHash, StringComparison.OrdinalIgnoreCase);
        }

        #region object level members

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="right">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Settings);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (this.DayOneFolderPath == null ? 0 : this.DayOneFolderPath.GetHashCode()) ^
                (this.PasswordHash == null ? 0 : this.PasswordHash.GetHashCode());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Folder: \"" + this.DayOneFolderPath + "\", Hash: \"" + this.PasswordHash + "\"";
        }

        #region IEquatable<Settings> Members

        /// <summary>
        /// Determines whether the specified <see cref="Settings" /> is equal to this instance.
        /// </summary>
        /// <param name="right">The <see cref="Settings" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="Settings" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Settings right)
        {
            if (this.PasswordHash != right.PasswordHash)
            {
                return false;
            }

            if (this.DayOneFolderPath != right.DayOneFolderPath)
            {
                return false;
            }

            return true;
        }

        #endregion

        #endregion

        /// <summary>
        /// Gets the file path under %APPDATA% folder.
        /// Creates "Journaley" folder if it doesn't exist.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>the full file path combined with the %APPDATA%/Journaley folder.</returns>
        internal static string GetFilePathUnderApplicationData(string filename)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SettingsFolder);
            DirectoryInfo dinfo = new DirectoryInfo(path);
            if (!dinfo.Exists)
            {
                dinfo.Create();
            }

            return Path.Combine(path, filename);
        }

        /// <summary>
        /// Gets the settings file path under the %APPDATA% folder.
        /// Creates "Journaley" folder if it doesn't exist.
        /// </summary>
        /// <returns>The settings file path</returns>
        private static string GetSettingsFilePath()
        {
            return GetFilePathUnderApplicationData(SettingsFilename);
        }
    }
}
