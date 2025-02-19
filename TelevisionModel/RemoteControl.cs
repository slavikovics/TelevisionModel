using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelevisionModel.Data;

namespace TelevisionModel
{
    public class RemoteControl: Device
    {
        private Television PairedTelevision { get; set; }

        public delegate void PowerSwitch();
        
        public delegate void NextChannel();
        
        public delegate void PreviousChannel();
        
        public delegate void ChangeVolume(double newVolume);
        
        public PowerSwitch PowerSwitchPushed;
        
        public NextChannel NextChannelPushed;
        
        public PreviousChannel PreviousChannelPushed;

        public ChangeVolume ChangeVolumePushed;

        public RemoteControl(Television televisionToPair, string name, string function) : base(name, function)
        {
            if (televisionToPair is null) throw new ArgumentException(Resources.TelevisionToPairIsNullErrorMessage);
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
