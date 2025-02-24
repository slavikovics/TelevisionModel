using TelevisionModel.Content;

namespace TelevisionModel.TelevisionStates;

public class MainMenuState : ITelevisionState
{
    public ActionResult SwitchToNextChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        return new ActionResult("Switching channels is not available in this state.");
    }

    public ActionResult SwitchToPreviousChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        return new ActionResult("Switching channels is not available in this state.");
    }

    public ActionResult EditVolume(SoundSystem soundSystem, double newVolume)
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

    public ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY)
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

    public ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
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

    public ActionResult SwitchToMainMenuState(Television television)
    {
        return new ActionResult("Switching to main menu state is not available in this state.");
    }

    public ActionResult SwitchToTurnedOffState(Television television)
    {
        television.CurrentState = new TurnedOffState();
        return new ActionResult(".");
    }

    public ActionResult SwitchToTelevisionBroadcastingState(Television television)
    {
        throw new NotImplementedException();
    }

    public ActionResult SwitchToStreamingState(Television television)
    {
        throw new NotImplementedException();
    }

    public ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice)
    {
        throw new NotImplementedException();
    }
}