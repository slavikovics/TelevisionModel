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
        public string Name { get; }
        
        private string LogoPath { get; }

        public TelevisionChannel(string logoPath, string name)
        {
            LogoPath = logoPath;
            Name = name;
        }

        public override string ToString()
        {
            return $"Channel: {Name} {Environment.NewLine}LogoPath: {BuildLogoUrl()}.";
        }
        
        public string BuildLogoUrl()
        {
            return Resources.BaseUrl + LogoPath;
        }
    }
}
