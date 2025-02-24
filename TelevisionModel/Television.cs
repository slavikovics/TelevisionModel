using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.TelevisionStates;

namespace TelevisionModel
{
    public class Television
    {
        private SoundSystem SoundSystem { get; }
        
        private Screen Screen { get; }
        
        private ChannelBroadcastingSystem CurrentChannelBroadcastingSystem { get; }
        
        public ITelevisionState CurrentState { get; set; } 

        public Television(SoundSystem soundSystem, Screen screen)
        {
            SoundSystem = soundSystem;
            Screen = screen;
            CurrentState = new TurnedOffState();
            CurrentChannelBroadcastingSystem = new ChannelBroadcastingSystem();
        }

        public void RegisterRemoteControl(RemoteControl remoteControl)
        {
            remoteControl.PowerSwitchButtonPushed += PowerSwitchPushed;
            remoteControl.PreviousChannelButtonPushed += SwitchToPreviousChannel;
            remoteControl.NextChannelButtonPushed += SwitchToNextChannel;
            remoteControl.EditVolumeuttonPushed += EditVolume;
        }

        public void UnregisterRemoteControl(RemoteControl remoteControl)
        {
            try
            {
                remoteControl.PowerSwitchButtonPushed -= PowerSwitchPushed;
                remoteControl.PreviousChannelButtonPushed -= SwitchToPreviousChannel;
                remoteControl.NextChannelButtonPushed -= SwitchToNextChannel;
                remoteControl.EditVolumeuttonPushed -= EditVolume;
            }
            catch (Exception e)
            {
                throw new Exception($"{Resources.FaildToUnregisterRemoteControlErrorMessage} Name: {remoteControl.Name}", e);
            }
        }

        private ActionResult TurnOn()
        {
            return CurrentState.SwitchToMainMenuState(this);
        }

        private ActionResult TurnOff()
        {
            return CurrentState.SwitchToTurnedOffState(this);
        }

        private ActionResult PowerSwitchPushed()
        {
            if (CurrentState is not TurnedOffState) return TurnOff();
            return TurnOn();
        }

        private ActionResult SwitchToNextChannel()
        {
            return CurrentState.SwitchToNextChannel(CurrentChannelBroadcastingSystem);
        }

        private ActionResult SwitchToPreviousChannel()
        {
            return CurrentState.SwitchToPreviousChannel(CurrentChannelBroadcastingSystem);
        }

        private ActionResult EditVolume(double newVolume)
        {
            return CurrentState.EditVolume(SoundSystem, newVolume);
        }
    }
}
