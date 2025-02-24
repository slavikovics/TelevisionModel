using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelevisionModel.Data;

namespace TelevisionModel.Content
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
            return Resources.BaseUrl + LogoPath;
        }

        public override string ToString()
        {
            return $"Channel: {Name} {Environment.NewLine} LogoPath: {LogoPath}.";
        }
    }
}
