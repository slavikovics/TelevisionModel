using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.TelevisionStates;

namespace TelevisionModel
{
    public class Television
    {
        private SoundSystem SoundSystem { get; }
        
        private Screen Screen { get; }
        
        private Software Software { get; }
        
        private ChannelBroadcastingSystem CurrentChannelBroadcastingSystem { get; }
        
        public ITelevisionState CurrentState { get; set; } 

        public Television(SoundSystem soundSystem, Screen screen)
        {
            SoundSystem = soundSystem;
            Screen = screen;
            CurrentState = new TurnedOffState();
            CurrentChannelBroadcastingSystem = new ChannelBroadcastingSystem();
            Software = new Software("1.0");
        }

        public void RegisterRemoteControl(RemoteControl remoteControl)
        {
            remoteControl.PowerSwitchButtonPushed += PowerSwitchPushed;
            remoteControl.PreviousChannelButtonPushed += SwitchToPreviousChannel;
            remoteControl.NextChannelButtonPushed += SwitchToNextChannel;
            remoteControl.EditVolumeButtonPushed += EditVolume;
            remoteControl.ChangeResolutionButtonPushed += ChangeResolution;
            remoteControl.UpdateSoftwareButtonPushed += UpdateSoftware;
            remoteControl.MainMenuButtonPushed += SwitchToMainMenuState;
            remoteControl.TelevisionBroadcastingButtonPushed += SwitchToTelevisionBroadcastingState;
            remoteControl.StreamingButtonPushed += SwitchToStreamingState;
            remoteControl.ExternalDeviceScreencastButtonPushed += SwitchToExternalDeviceScreencastState;
        }

        public void UnregisterRemoteControl(RemoteControl remoteControl)
        {
            try
            {
                remoteControl.PowerSwitchButtonPushed -= PowerSwitchPushed;
                remoteControl.PreviousChannelButtonPushed -= SwitchToPreviousChannel;
                remoteControl.NextChannelButtonPushed -= SwitchToNextChannel;
                remoteControl.EditVolumeButtonPushed -= EditVolume;
                remoteControl.ChangeResolutionButtonPushed -= ChangeResolution;
                remoteControl.UpdateSoftwareButtonPushed -= UpdateSoftware;
                remoteControl.MainMenuButtonPushed -= SwitchToMainMenuState;
                remoteControl.TelevisionBroadcastingButtonPushed -= SwitchToTelevisionBroadcastingState;
                remoteControl.StreamingButtonPushed -= SwitchToStreamingState;
                remoteControl.ExternalDeviceScreencastButtonPushed -= SwitchToExternalDeviceScreencastState;
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
        
        private ActionResult ChangeResolution(double newResolutionX, double newResolutionY)
        {
            return CurrentState.ChangeResolution(Screen, newResolutionX, newResolutionY);
        }
        
        private ActionResult UpdateSoftware(string newSoftwareVersion)
        {
            return CurrentState.UpdateSoftware(Software, newSoftwareVersion);
        }
        
        private ActionResult SwitchToMainMenuState()
        {
            return CurrentState.SwitchToMainMenuState(this);
        }
        
        private ActionResult SwitchToTelevisionBroadcastingState()
        {
            return CurrentState.SwitchToTelevisionBroadcastingState(this);
        }
        
        private ActionResult SwitchToStreamingState()
        {
            return CurrentState.SwitchToStreamingState(this);
        }
        
        private ActionResult SwitchToExternalDeviceScreencastState(Device externalDevice)
        {
            return CurrentState.SwitchToExternalDeviceScreencastState(this, externalDevice);
        }
    }
}
