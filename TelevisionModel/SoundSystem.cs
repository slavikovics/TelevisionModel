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
        
        public bool IsTurnedOn { get; private set; }

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

        public void TurnOn()
        {
            if (IsTurnedOn)
            {
                throw new InvalidOperationException("The sound system is already turned on");
            }
            
            IsTurnedOn = true;
        }

        public void TurnOff()
        {
            if (!IsTurnedOn)
            {
                throw new InvalidOperationException("The sound system is not turned on");
            }
            
            IsTurnedOn = false;
        }
    }
}
