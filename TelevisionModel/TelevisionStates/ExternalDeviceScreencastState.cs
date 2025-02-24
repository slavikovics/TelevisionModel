using TelevisionModel.Content;

namespace TelevisionModel.TelevisionStates;

public class ExternalDeviceScreencastState : ITelevisionState
{
    public ActionResult SwitchToNextChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        throw new NotImplementedException();
    }

    public ActionResult SwitchToPreviousChannel(ChannelBroadcastingSystem channelBroadcastingSystem)
    {
        throw new NotImplementedException();
    }

    public ActionResult EditVolume(SoundSystem soundSystem, double newVolume)
    {
        throw new NotImplementedException();
    }

    public ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY)
    {
        throw new NotImplementedException();
    }

    public ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
    {
        throw new NotImplementedException();
    }

    public ActionResult SwitchToMainMenuState(Television television)
    {
        throw new NotImplementedException();
    }

    public ActionResult SwitchToTurnedOffState(Television television)
    {
        throw new NotImplementedException();
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