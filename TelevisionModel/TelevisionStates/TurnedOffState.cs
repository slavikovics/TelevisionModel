using TelevisionModel.Content;

namespace TelevisionModel.TelevisionStates;

public class TurnedOffState : ITelevisionState
{
    public ActionResult SwitchToNextChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        return new ActionResult("Cannot switch to next channel in this state.");
    }

    public ActionResult SwitchToPreviousChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        return new ActionResult("Cannot switch to previous channel in this state.");
    }

    public ActionResult EditVolume(SoundSystem soundSystem, double newVolume)
    {
        return new ActionResult("Cannot change volume in this state.");
    }

    public ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY)
    {
        return new ActionResult("Cannot change resolution in this state.");
    }

    public ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
    {
        return new ActionResult("Cannot update software in this state.");
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
        return new ActionResult("Cannot switch to this state.");
    }

    public ActionResult SwitchToStreamingState(Television television)
    {
        return new ActionResult("Cannot switch to this state.");
    }

    public ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice)
    {
        return new ActionResult("Cannot switch to this state.");
    }
}