using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TelevisionModel.Data;

namespace TelevisionModel
{
    public class Television
    {
        private SoundSystem SoundSystem { get; }

        private Screen Screen { get; }
        
        private bool IsTurnedOn { get; set; }
        
        private List<Device> ConnectedDevices { get; set; }
        
        private List<TelevisionChannel> AvailableChannels { get; set; }
        
        private int SelectedChannel { get; set; }
        
        public TechnicalSpecifications TechnicalSpecifications { get; private set; }

        public Television(SoundSystem soundSystem, Screen screen)
        {
            ConnectedDevices = new List<Device>();
            AvailableChannels = new List<TelevisionChannel>();
            IsTurnedOn = false;
            SelectedChannel = 0;
            SoundSystem = soundSystem;
            Screen = screen;
            AvailableChannels = SignalTransmitter.FindChannels();
        }

        public void RegisterRemoteControl(RemoteControl remoteControl)
        {
            remoteControl.PowerSwitchPushed += PowerSwitchPushed;
            remoteControl.PreviousChannelPushed += SelectPreviousChannel;
            remoteControl.NextChannelPushed += SelectNextChannel;
            remoteControl.ChangeVolumePushed += SoundSystem.EditVolume;
        }

        public void UnregisterRemoteControl(RemoteControl remoteControl)
        {
            try
            {
                remoteControl.PowerSwitchPushed -= PowerSwitchPushed;
                remoteControl.PreviousChannelPushed -= SelectPreviousChannel;
                remoteControl.NextChannelPushed -= SelectNextChannel;
                remoteControl.ChangeVolumePushed -= SoundSystem.EditVolume;
            }
            catch (Exception e)
            {
                throw new Exception($"{Resources.FaildToUnregisterRemoteControlErrorMessage} Name: {remoteControl.Name}", e);
            }
        }

        private void TurnOn()
        {
            if (IsTurnedOn)
            {
                throw new InvalidOperationException(Resources.TelevisionIsAlreadyTurnedOnErrorMessage);
            }
            
            Screen.TurnOn();
            SoundSystem.TurnOn();
            IsTurnedOn = true;
        }

        private void TurnOff()
        {
            if (!IsTurnedOn)
            {
                throw new InvalidOperationException(Resources.TelevisionIsNotTurnedOnErrorMessage);
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

        public void SelectNextChannel()
        {
            if (!IsTurnedOn) throw new InvalidOperationException(Resources.TelevisionIsNotTurnedOnErrorMessage);

            SelectedChannel++;
            if (SelectedChannel >= AvailableChannels.Count) SelectedChannel = 0;
        }

        public void SelectPreviousChannel()
        {
            if (!IsTurnedOn) throw new InvalidOperationException(Resources.TelevisionIsNotTurnedOnErrorMessage);

            SelectedChannel--;
            if (SelectedChannel < 0) SelectedChannel = AvailableChannels.Count - 1;
        }
    }
}
