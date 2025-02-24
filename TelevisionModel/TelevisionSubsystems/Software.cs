﻿using System.Text.RegularExpressions;

namespace TelevisionModel
{
    public class Software
    {
        private string InstalledVersion { get; set; }

        public Software(string installedVersion)
        {
            InstalledVersion = installedVersion;
        }

        public void UpdateSoftware(string newVersion)
        {
            string pattern = @"^[0-9.]+$";
            bool isMatch = Regex.IsMatch(newVersion, pattern);

            if (!isMatch)
            {
                throw new ArgumentException("Invalid version. Version can only contain numbers and dots.");
            }
            
            if (InstalledVersion == newVersion) throw new Exception("The latest version of software is already installed.");
            InstalledVersion = newVersion;
        }
    }
}
