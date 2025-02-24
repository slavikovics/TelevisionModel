using TelevisionModel.Content;

namespace TelevisionModel.TelevisionStates;

public class TurnedOffState : ITelevisionState
{
    public ActionResult SwitchToNextChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        return new ActionResult("Cannot switch to next channel, when television is turned off.");
    }

    public ActionResult SwitchToPreviousChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        return new ActionResult("Cannot switch to previous channel, when television is turned off.");
    }

    public ActionResult EditVolume(SoundSystem soundSystem, double newVolume)
    {
        return new ActionResult("Cannot change volume, when television is turned off.");
    }

    public ActionResult ChangeResolution(Screen screen, double newResolutionX, double newResolutionY)
    {
        return new ActionResult("Cannot change resolution, when television is turned off.");
    }

    public ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
    {
        return new ActionResult("Cannot update software, when television is turned off.");
    }

    public ActionResult SwitchToMainMenuState(Television television)
    {
        television.CurrentState = new MainMenuState();
        return new ActionResult("Television has been turned on successfully. Now you are in a main menu.");
    }

    public ActionResult SwitchToTurnedOffState(Television television)
    {
        return new ActionResult("Television is already turned off.");
    }

    public ActionResult SwitchToTelevisionBroadcastingState(Television television)
    {
        return new ActionResult("Cannot switch to television broadcasting state, when television is turned off.");
    }

    public ActionResult SwitchToStreamingState(Television television)
    {
        return new ActionResult("Cannot switch to streaming state, when television is turned off.");
    }

    public ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice)
    {
        return new ActionResult("Cannot switch to external device screencast state, when television is turned off.");
    }
}