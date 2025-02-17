using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class RemoteControl: Device
    {
        private Television PairedTelevision { get; set; }

        public delegate void PowerSwitch();
        
        public delegate void NextChannel();
        
        public delegate void PreviousChannel();
        
        private delegate void ChangeVolumePushed();
        
        public PowerSwitch PowerSwitchPushed;
        
        public NextChannel NextChannelPushed;
        
        public PreviousChannel PreviousChannelPushed;

        public RemoteControl(Television televisionToPair, string name, string function) : base(name, function)
        {
            if (televisionToPair is null) throw new ArgumentException("Television to Pair is null");
            PairedTelevision = televisionToPair;
            PairedTelevision.RegisterRemoteControl(this);
        }

        public void Pair(Television televisionToPair)
        {
            PairedTelevision.UnregisterRemoteControl(this);
            PairedTelevision = televisionToPair;
            PairedTelevision.RegisterRemoteControl(this);
        }

        public void PushPowerSwitch()
        {
            PowerSwitchPushed?.Invoke();
        }

        public void PushNextChannel()
        {
            NextChannelPushed?.Invoke();
        }

        public void PushPreviousChannel()
        {
            PreviousChannelPushed?.Invoke();
        }
    }
}
