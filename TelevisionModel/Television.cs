using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Television
    {
        private TelevisionChanel CurrentTelevisionChanel { get; set; }
        
        public SoundSystem SoundSystem { get; set; }

        public Screen Screen { get; set; }

        public Television()
        {
        }
    }
}
