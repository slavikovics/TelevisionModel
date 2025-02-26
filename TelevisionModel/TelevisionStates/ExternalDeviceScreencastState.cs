using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.TelevisionSubsystems;
using TelevisionModel.Utils;

namespace TelevisionModel.TelevisionStates;

public class ExternalDeviceScreencastState : TurnedOnStateBase
{
    public override ActionResult SwitchToNextChannel(IContentProvider contentProvider)
    {
        return new ActionResult(Resources.CannotSwitchToNext);
    }
    
    public override ActionResult SwitchToPreviousChannel(IContentProvider contentProvider)
    {
        return new ActionResult(Resources.CannotSwitchToPrevious);
    }
    
    public override ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY)
    {
        return new ActionResult(Resources.CannotChangeResolution);
    }
    
    public override ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
    {
        return new ActionResult(Resources.CannotUpdateSoftware);
    }
    
    public override ActionResult SwitchToExternalDeviceScreencastState(Television television, Device externalDevice)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }
}