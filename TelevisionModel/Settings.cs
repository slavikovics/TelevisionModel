using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Settings
    {
        public string Language { get; set; }
        
        public string Password { get; set; }

        public Settings(string language, string password)
        {
            Language = language;
            Password = password;
        }
    }
}
