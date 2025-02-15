using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class RemoteControl: Device
    {
        public Television PairedTelevision { get; set; }

        private delegate void PowerSwitchPushed();
        
        private PowerSwitchPushed _powerSwitchPushed;

        public RemoteControl(Television televisionToPair, string name, string function) : base(name, function)
        {
            if (televisionToPair is null) throw new ArgumentException("Television to Pair is null");
            PairedTelevision = televisionToPair;
            _powerSwitchPushed += PairedTelevision.PowerSwitchPushed;
        }

        public void Pair(Television televisionToPair)
        {
            _powerSwitchPushed -= PairedTelevision.PowerSwitchPushed;
            PairedTelevision = televisionToPair;
            
            _powerSwitchPushed += PairedTelevision.PowerSwitchPushed;
        }

        public void PushPowerSwitch()
        {
            _powerSwitchPushed?.Invoke();
        }
    }
}
