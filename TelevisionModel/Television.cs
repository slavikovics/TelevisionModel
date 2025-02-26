using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.TelevisionStates;
using TelevisionModel.Utils;

namespace TelevisionModel
{
    public class Television
    {
        private SoundSystem SoundSystem { get; }
        
        private Screen Screen { get; }
        
        private Software Software { get; }
        
        public ChannelBroadcastingSystem CurrentChannelBroadcastingSystem { get; }
        
        public StreamingService StreamingService { get; }
        
        public ITelevisionState CurrentState { get; set; }
        
        public IContentProvider ContentProvider { get; set; }
        
        public States State { get; set; }
        
        public TechnicalSpecifications Specifications { get; private set; }

        public Television(SoundSystem soundSystem, Screen screen)
        {
            SoundSystem = soundSystem;
            Screen = screen;
            CurrentState = new TurnedOffState();
            CurrentChannelBroadcastingSystem = new ChannelBroadcastingSystem();
            StreamingService = new StreamingService();
            Software = new Software();
            CurrentState = new TurnedOffState();
            Specifications = new TechnicalSpecifications(Screen, SoundSystem, Software, State, CurrentChannelBroadcastingSystem, StreamingService);
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
            CurrentState = new MainMenuState();
            State = States.MainMenu;
            UpdateTechnicalSpecifications();
            return new ActionResult(Resources.ChangedToMainMenuState).AddSpecifications(Specifications);
        }

        private ActionResult TurnOff()
        {
            UpdateTechnicalSpecifications();
            return CurrentState.SwitchToTurnedOffState(this).AddSpecifications(Specifications);
        }

        private ActionResult PowerSwitchPushed()
        {
            if (CurrentState is not TurnedOffState) return TurnOff();
            return TurnOn();
        }

        private ActionResult SwitchToNextChannel()
        {
            UpdateTechnicalSpecifications();
            return CurrentState.SwitchToNextChannel(ContentProvider).AddSpecifications(Specifications);
        }

        private ActionResult SwitchToPreviousChannel()
        {
            UpdateTechnicalSpecifications();
            return CurrentState.SwitchToPreviousChannel(ContentProvider).AddSpecifications(Specifications);
        }

        private ActionResult EditVolume(double newVolume)
        {
            UpdateTechnicalSpecifications();
            return CurrentState.EditVolume(SoundSystem, newVolume).AddSpecifications(Specifications);
        }
        
        private ActionResult ChangeResolution(int newResolutionX, int newResolutionY)
        {
            UpdateTechnicalSpecifications();
            return CurrentState.ChangeResolution(Screen, newResolutionX, newResolutionY).AddSpecifications(Specifications);
        }
        
        private ActionResult UpdateSoftware(string newSoftwareVersion)
        {
            UpdateTechnicalSpecifications();
            return CurrentState.UpdateSoftware(Software, newSoftwareVersion).AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToMainMenuState()
        {
            UpdateTechnicalSpecifications();
            return CurrentState.SwitchToMainMenuState(this).AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToTelevisionBroadcastingState()
        {
            UpdateTechnicalSpecifications();
            return CurrentState.SwitchToTelevisionBroadcastingState(this).AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToStreamingState()
        {
            UpdateTechnicalSpecifications();
            return CurrentState.SwitchToStreamingState(this).AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToExternalDeviceScreencastState(Device externalDevice)
        {
            UpdateTechnicalSpecifications();
            return CurrentState.SwitchToExternalDeviceScreencastState(this, externalDevice).AddSpecifications(Specifications);
        }

        public string UpdateTechnicalSpecifications()
        {
            Specifications.Update(State, Screen, SoundSystem, Software, CurrentChannelBroadcastingSystem, StreamingService);
            return Specifications.ToString();
        }
    }
}
