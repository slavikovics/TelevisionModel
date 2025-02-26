using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.Data;
using TelevisionModel.TelevisionSubsystems;
using TelevisionModel.Utils;

namespace TelevisionModel.TelevisionStates;

public class TelevisionBroadcastingState : TurnedOnStateBase
{
    public override ActionResult ChangeResolution(Screen screen, int newResolutionX, int newResolutionY)
    {
        return new ActionResult(Resources.CannotChangeResolution);
    }
    
    public override ActionResult UpdateSoftware(Software software, string newSoftwareVersion)
    {
        return new ActionResult(Resources.CannotUpdateSoftware);
    }
    
    public override ActionResult SwitchToTelevisionBroadcastingState(Television television)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }
}