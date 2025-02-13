using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class SoundSystem
    {
        public double MinFrequency { get; set; }
        public double MaxFrequency { get; set; }
        public double Volume { get; set; }

        public SoundSystem(double minFrequency, double maxFrequency, double volume)
        {
            MinFrequency = minFrequency;
            MaxFrequency = maxFrequency;
            Volume = volume;
        }
    }
}
