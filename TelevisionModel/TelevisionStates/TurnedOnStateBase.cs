using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.Data;
using TelevisionModel.Data;
using TelevisionModel.Utils;

namespace TelevisionModel.TelevisionStates;

public abstract class TurnedOnStateBase : ITelevisionState
{
    public virtual ActionResult SwitchToNextChannel(IContentProvider contentProvider)
    {
        try
        {
            return contentProvider.SwitchToNext();
        }
        catch (Exception e)
        {
            return new ActionResult(e.Message);
        }
    }

    public virtual ActionResult SwitchToPreviousChannel(IContentProvider contentProvider)
    {
        try
        {
            return contentProvider.SwitchToPrevious();
        }
        catch (Exception e)
        {
            return new ActionResult(e.Message);
        }
    }

    public virtual ActionResult EditVolume(SoundSystem soundSystem, double newVolume)
    {
        try
        {
            soundSystem.EditVolume(newVolume);
        }
        catch (ArgumentException e)
        {
            return new ActionResult(e.Message);
        }
        
        return new ActionResult($"The volume was edited successfully. Current volume level is: {soundSystem.Volume}%");
    }

    public virtual ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY)
    {
        try
        {
            screen.ChangeResolution(newResolutionX, newResolutionY);
        }
        catch (ArgumentException e)
        {
            return new ActionResult(e.Message);
        }
        
        return new ActionResult($"The resolution was changed to {newResolutionX} X {newResolutionY}.");
    }

    public virtual ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
    {
        try
        {
            software.UpdateSoftware(newSoftwareVersion);
        }
        catch (Exception e)
        {
            return new ActionResult(e.Message);
        }
        
        return new ActionResult($"The software version was changed to {newSoftwareVersion}.");
    }

    public virtual ActionResult SwitchToMainMenuState(Television television)
    {
        television.CurrentState = new MainMenuState();
        television.State = States.MainMenu;
        return new ActionResult(Resources.ChangedToMainMenuState);
    }

    public virtual ActionResult SwitchToTurnedOffState(Television television)
    {
        television.CurrentState = new TurnedOffState();
        television.State = States.TurnedOff;
        return new ActionResult(Resources.ChangedToTurnedOffState);
    }

    public virtual ActionResult SwitchToTelevisionBroadcastingState(Television television)
    {
        television.CurrentState = new TelevisionBroadcastingState();
        television.State = States.TelevisionBroadcasting;
        return new ActionResult(Resources.ChangedToTelevisionBroadcastingState);
    }

    public virtual ActionResult SwitchToStreamingState(Television television)
    {
        television.CurrentState = new StreamingState();
        television.State = States.Streaming;
        return new ActionResult(Resources.ChangedToStreamingState);
    }

    public virtual ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice)
    {
        television.CurrentState = new TurnedOffState();
        television.State = States.ExternalDeviceScreencast;
        return new ActionResult(Resources.ChangedToExternalDeviceScreencastState);
    }
}