using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class TelevisionChannel
    {
        public string LogoPath { get; }
        
        public string Name { get; }

        public TelevisionChannel(string logoPath, string name)
        {
            LogoPath = logoPath;
            Name = name;
        }

        public string BuildLogoUrl()
        {
            return "https://jaruba.github.io/channel-logos/export/transparent-color/" + LogoPath;
        }
    }
}
