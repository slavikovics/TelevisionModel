using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class SoundSystem
    {
        public double Volume { get; private set; }

        public bool IsMuted { get; private set; }

        public SoundSystem()
        {
            Volume = 0;
            IsMuted = true;
        }

        public void EditVolume(double newVolume)
        {
            if (newVolume is < 0 or > 100)
            {
                throw new ArgumentException("Volume must be between 0 and 100.");
            }

            IsMuted = !(newVolume > 0);
            Volume = newVolume;
        }
    }
}
