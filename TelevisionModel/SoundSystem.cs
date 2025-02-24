namespace TelevisionModel
{
    public class SoundSystem
    {
        public double Volume { get; private set; }
        
        public double Power { get; }

        public bool IsMuted { get; private set; }
        
        private bool IsTurnedOn { get; set; }

        public SoundSystem(double power)
        {
            if (power <= 0) throw new ArgumentException("Invalid power value");
            
            Volume = 0;
            IsMuted = true;
            Power = power;
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
