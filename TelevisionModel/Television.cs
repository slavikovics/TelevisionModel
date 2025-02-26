using System.Threading.Tasks.Dataflow;
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
            State = States.TurnedOff;
            SoundSystem = soundSystem;
            Screen = screen;
            CurrentState = new TurnedOffState();
            CurrentChannelBroadcastingSystem = new ChannelBroadcastingSystem();
            StreamingService = new StreamingService();
            Software = new Software();
            CurrentState = new TurnedOffState();
            Specifications = new TechnicalSpecifications();
            UpdateTechnicalSpecifications();
        }

        public Television(SoundSystem soundSystem, Screen screen, Software software, ChannelBroadcastingSystem channelBroadcastingSystem, 
            StreamingService streamingService, States state)
        {
            SoundSystem = soundSystem;
            Screen = screen;
            Software = software;
            State = state;
            StreamingService = streamingService;
            CurrentChannelBroadcastingSystem = channelBroadcastingSystem;
            StreamingService = streamingService;
            Specifications = new TechnicalSpecifications();
            UpdateTechnicalSpecifications();
            ReloadState(state);
        }

        private void ReloadState(States state)
        {
            switch (state)
            {
                case States.MainMenu: CurrentState = new MainMenuState(); 
                    break;
                case States.TelevisionBroadcasting: CurrentState = new TelevisionBroadcastingState();
                    ContentProvider = CurrentChannelBroadcastingSystem;
                    break;
                case States.Streaming: CurrentState = new StreamingState();
                    ContentProvider = StreamingService;
                    break;
                case States.ExternalDeviceScreencast: CurrentState = new ExternalDeviceScreencastState();
                    break;
                default: CurrentState = new TurnedOffState();
                    break;
            }

            UpdateTechnicalSpecifications();
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
            State = States.TurnedOff;
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
            ActionResult result = CurrentState.SwitchToNextChannel(ContentProvider);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }

        private ActionResult SwitchToPreviousChannel()
        {
            ActionResult result = CurrentState.SwitchToPreviousChannel(ContentProvider);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }

        private ActionResult EditVolume(double newVolume)
        {
            ActionResult result = CurrentState.EditVolume(SoundSystem, newVolume);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }
        
        private ActionResult ChangeResolution(int newResolutionX, int newResolutionY)
        {
            ActionResult result = CurrentState.ChangeResolution(Screen, newResolutionX, newResolutionY);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }
        
        private ActionResult UpdateSoftware(string newSoftwareVersion)
        {
            ActionResult result = CurrentState.UpdateSoftware(Software, newSoftwareVersion);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToMainMenuState()
        {
            ActionResult result = CurrentState.SwitchToMainMenuState(this);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToTelevisionBroadcastingState()
        {
            ActionResult result = CurrentState.SwitchToTelevisionBroadcastingState(this);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToStreamingState()
        {
            ActionResult result = CurrentState.SwitchToStreamingState(this);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }
        
        private ActionResult SwitchToExternalDeviceScreencastState(Device externalDevice)
        {
            ActionResult result = CurrentState.SwitchToExternalDeviceScreencastState(this, externalDevice);
            UpdateTechnicalSpecifications();
            return result.AddSpecifications(Specifications);
        }

        private string UpdateTechnicalSpecifications()
        {
            Specifications.Update(State, Screen, SoundSystem, Software, CurrentChannelBroadcastingSystem, StreamingService);
            return Specifications.ToString();
        }
    }
}
