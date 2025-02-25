using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.Utils;

namespace TelevisionModel.TelevisionStates;

public class MainMenuState : TurnedOnStateBase
{
    public override ActionResult SwitchToNextChannel(IContentProvider contentProvider)
    {
        return new ActionResult(Resources.CannotSwitchToNext);
    }
    
    public override ActionResult SwitchToPreviousChannel(IContentProvider contentProvider)
    {
        return new ActionResult(Resources.CannotSwitchToPrevious);
    }
    
    public override ActionResult SwitchToMainMenuState(Television television)
    {
        return new ActionResult(Resources.CannotSwitchToThisState);
    }
}