using TelevisionModel.Data;

namespace TelevisionModel.TelevisionSubsystems
{
    public class SoundSystem
    {
        public double Volume { get; private set; }
        
        public double Power { get; }

        public bool IsMuted { get; private set; }

        public SoundSystem(double power)
        {
            if (power <= 0) throw new ArgumentException(Resources.InvalidPowerValue);
            
            Volume = 0;
            IsMuted = true;
            Power = power;
        }

        public void EditVolume(double newVolume)
        {
            if (newVolume is < 0 or > 100)
            {
                throw new ArgumentException(Resources.InvalidVolume);
            }

            IsMuted = !(newVolume > 0);
            Volume = newVolume;
        }
    }
}
