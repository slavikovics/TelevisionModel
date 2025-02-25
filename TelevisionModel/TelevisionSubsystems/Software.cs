using System.Text.RegularExpressions;

namespace TelevisionModel
{
    public class Software
    {
        public string InstalledVersion { get; private set; }

        public Software(string installedVersion = "0.0")
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
