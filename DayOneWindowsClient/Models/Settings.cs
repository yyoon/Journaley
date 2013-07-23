using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace DayOneWindowsClient.Models
{
    [Serializable]
    public class Settings : IEquatable<Settings>, IPasswordVerifier
    {
        private static readonly string SETTINGS_FOLDER = "DayOneWindowsClient";
        private static readonly string SETTINGS_FILENAME = "DayOneWindowsClient.settings";

        public Settings()
        {
            this.PasswordHash = null;
            this.DayOneFolderPath = null;
        }

        public Settings(Settings other)
        {
            this.PasswordHash = other.PasswordHash;
            this.DayOneFolderPath = other.DayOneFolderPath;
        }

        private static string GetSettingsFilePath()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SETTINGS_FOLDER);
            DirectoryInfo dinfo = new DirectoryInfo(path);
            if (!dinfo.Exists)
            {
                dinfo.Create();
            }

            return Path.Combine(path, SETTINGS_FILENAME);
        }

        public static Settings GetSettingsFile()
        {
            return GetSettingsFile(GetSettingsFilePath());
        }

        public static Settings GetSettingsFile(string path)
        {
            if (!File.Exists(path))
                return null;

            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    Settings settings = serializer.Deserialize(sr) as Settings;

                    if (!Directory.Exists(settings.DayOneFolderPath))
                        return null;

                    return settings;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Reuse the MD5 object.
        private static MD5 _md5 = null;
        private static MD5 MD5Instance
        {
            get
            {
                if (_md5 == null)
                    _md5 = MD5.Create();

                return _md5;
            }
        }

        public string PasswordHash { get; set; }
        public string DayOneFolderPath { get; set; }

        public string Password
        {
            set
            {
                this.PasswordHash = ComputeMD5Hash(value);
            }
        }

        public bool HasPassword
        {
            get
            {
                return this.PasswordHash != null;
            }
        }

        public bool Save()
        {
            return Save(GetSettingsFilePath());
        }

        public bool Save(string path)
        {
            if (!Directory.Exists(this.DayOneFolderPath))
                return false;

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

        public bool VerifyPassword(string inputPassword)
        {
            string inputHash = ComputeMD5Hash(inputPassword);
            return string.Equals(PasswordHash, inputHash, StringComparison.OrdinalIgnoreCase);
        }

        #region object level members

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null))
                return false;

            if (object.ReferenceEquals(this, right))
                return true;

            if (this.GetType() != right.GetType())
                return false;

            return this.Equals(right as Settings);
        }

        public override int GetHashCode()
        {
            return (this.DayOneFolderPath == null ? 0 : this.DayOneFolderPath.GetHashCode()) ^
                (this.PasswordHash == null ? 0 : this.PasswordHash.GetHashCode());
        }

        public override string ToString()
        {
            return "Folder: \"" + this.DayOneFolderPath + "\", Hash: \"" + this.PasswordHash + "\"";
        }

        #region IEquatable<Settings> Members

        public bool Equals(Settings right)
        {
            if (this.PasswordHash != right.PasswordHash)
                return false;

            if (this.DayOneFolderPath != right.DayOneFolderPath)
                return false;

            return true;
        }

        #endregion

        #endregion
    }
}
