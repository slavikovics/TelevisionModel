using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Software
    {
        public string InstalledVersion { get; set; }
        
        public string NewestVersion { get; set; }

        public Software(string installedVersion, string newestVersion)
        {
            InstalledVersion = installedVersion;
            NewestVersion = newestVersion;
        }
    }
}
