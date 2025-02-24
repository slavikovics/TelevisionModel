namespace TelevisionModel
{
    public class Software
    {
        public string InstalledVersion { get; set; }

        public Software(string installedVersion)
        {
            InstalledVersion = installedVersion;
        }

        public void UpdateSoftware(string newVersion)
        {
            if (InstalledVersion == newVersion) throw new Exception("The latest version of software is already installed.");
            InstalledVersion = newVersion;
        }
    }
}
