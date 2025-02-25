namespace TelevisionModel.Utils;

public class ActionResult
{
    public string MessageDescription { get; private set; }  
    
    public List<string> MessageDetails { get; private set; }

    public ActionResult(string messageDescription, List<string> messageDetails)
    {
        MessageDescription = messageDescription;
        MessageDetails = messageDetails;
    }

    public ActionResult(string messageDescription)
    {
        MessageDescription = messageDescription;
        MessageDetails = new List<string>();
    }
}