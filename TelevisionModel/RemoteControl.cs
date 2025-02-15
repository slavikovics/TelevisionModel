using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class RemoteControl
    {
        public Television PairedTelevision { get; set; }

        private delegate void PowerSwitchPushed();
        
        private PowerSwitchPushed _powerSwitchPushed;

        public void Pair(Television televisionToPair)
        {
            // TODO: check for null
            _powerSwitchPushed -= PairedTelevision.PowerSwitchPushed;
            PairedTelevision = televisionToPair;
            _powerSwitchPushed += PairedTelevision.PowerSwitchPushed;
        }

        public void PushPowerSwitch()
        {
            _powerSwitchPushed();
        }
    }
}
