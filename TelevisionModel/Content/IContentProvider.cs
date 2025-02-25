using TelevisionModel.Utils;

namespace TelevisionModel.Content;

public interface IContentProvider
{
    public ActionResult SwitchToNext();
    
    public ActionResult SwitchToPrevious();
}