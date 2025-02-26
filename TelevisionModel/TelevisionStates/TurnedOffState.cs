using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.Data;
using TelevisionModel.TelevisionSubsystems;
using TelevisionModel.Utils;

namespace TelevisionModel.TelevisionStates;

public class TurnedOffState : ITelevisionState
{
    public ActionResult SwitchToNextChannel(IContentProvider contentProvider)
    {
        return new ActionResult(Resources.CannotSwitchToNext);
    }

    public ActionResult SwitchToPreviousChannel(IContentProvider contentProvider)
    {
        return new ActionResult(Resources.CannotSwitchToPrevious);
    }

    public ActionResult EditVolume(SoundSystem soundSystem, double newVolume)
    {
        return new ActionResult(Resources.CannotChangeVolume);
    }

    public ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY)
    {
        return new ActionResult(Resources.CannotChangeResolution);
    }

    public ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
    {
        return new ActionResult(Resources.CannotUpdateSoftware);
    }

    public ActionResult SwitchToMainMenuState(Television television)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }

    public ActionResult SwitchToTurnedOffState(Television television)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }

    public ActionResult SwitchToTelevisionBroadcastingState(Television television)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }

    public ActionResult SwitchToStreamingState(Television television)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }

    public ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }
}