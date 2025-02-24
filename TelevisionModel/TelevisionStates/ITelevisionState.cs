using System.Threading.Channels;

namespace TelevisionModel.TelevisionStates;

public interface ITelevisionState
{
    public ActionResult SwitchToNextChannel(ChannelBroadcastingSystem channelBroadcastingSystem);
    
    public ActionResult SwitchToPreviousChannel(ChannelBroadcastingSystem channelBroadcastingSystem);

    public ActionResult ChangeVolume(SoundSystem soundSystem);

    public ActionResult ChangeResolution(Screen screen);

    public ActionResult UpdateSoftware(Software software);

    public ActionResult SwitchToMainMenuState(Television television);
    
    public ActionResult SwitchToTurnedOffState(Television television);
    
    public ActionResult SwitchToTelevisionBroadcastingState(Television television);
    
    public ActionResult SwitchToStreamingState(Television television);
    
    public ActionResult SwitchToExternalDeviceScreencastState(Television television);
}