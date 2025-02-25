﻿using TelevisionModel.Content;
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

        public Television(SoundSystem soundSystem, Screen screen)
        {
            SoundSystem = soundSystem;
            Screen = screen;
            CurrentState = new TurnedOffState();
            CurrentChannelBroadcastingSystem = new ChannelBroadcastingSystem();
            StreamingService = new StreamingService();
            Software = new Software();
            CurrentState = new TurnedOffState();
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
            return new ActionResult(Resources.ChangedToMainMenuState);
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
            return CurrentState.SwitchToNextChannel(ContentProvider);
        }

        private ActionResult SwitchToPreviousChannel()
        {
            return CurrentState.SwitchToPreviousChannel(ContentProvider);
        }

        private ActionResult EditVolume(double newVolume)
        {
            return CurrentState.EditVolume(SoundSystem, newVolume);
        }
        
        private ActionResult ChangeResolution(int newResolutionX, int newResolutionY)
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

        public TechnicalSpecifications BuildTechnicalSpecifications()
        {
            TechnicalSpecifications technicalSpecifications = new TechnicalSpecifications(Screen, SoundSystem, Software, State, 
                CurrentChannelBroadcastingSystem.SelectedChannelIndex, StreamingService.SelectedIndex);
            return technicalSpecifications;
        }
    }
}
