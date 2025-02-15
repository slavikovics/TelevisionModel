using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Television
    {
        private TelevisionChannel CurrentTelevisionChannel { get; set; }
        
        public SoundSystem SoundSystem { get; set; }

        public Screen Screen { get; set; }
        
        private bool IsTurnedOn { get; set; }
        
        List<Device> ConnectedDevices { get; set; }
        
        List<TelevisionChannel> AvailableChannels { get; set; }

        public Television()
        {
            ConnectedDevices = new List<Device>();
            IsTurnedOn = false;
        }

        private void TurnOn()
        {
            if (IsTurnedOn)
            {
                throw new InvalidOperationException("The television is already turned on");
            }
            
            Screen.TurnOn();
            SoundSystem.TurnOn();
            IsTurnedOn = true;
        }

        private void TurnOff()
        {
            if (!IsTurnedOn)
            {
                throw new InvalidOperationException("The television is not turned on");
            }
            
            Screen.TurnOff();
            SoundSystem.TurnOff();
            IsTurnedOn = false;
        }

        public void PowerSwitchPushed()
        {
            if (IsTurnedOn) TurnOff();
            else TurnOn();
        }
    }
}
