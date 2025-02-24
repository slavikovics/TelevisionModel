using TelevisionModel.Content;

namespace TelevisionModel.TelevisionStates;

public interface ITelevisionState
{
    public ActionResult SwitchToNextChannel(ChannelBroadcastingSystem channelBroadcastingSystem);
    
    public ActionResult SwitchToPreviousChannel(ChannelBroadcastingSystem channelBroadcastingSystem);

    public ActionResult EditVolume(SoundSystem soundSystem, double newVolume);

    public ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY);

    public ActionResult UpdateSoftware(Software software, string newSoftwareVersion);

    public ActionResult SwitchToMainMenuState(Television television);
    
    public ActionResult SwitchToTurnedOffState(Television television);
    
    public ActionResult SwitchToTelevisionBroadcastingState(Television television);
    
    public ActionResult SwitchToStreamingState(Television television);
    
    public ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice);
}