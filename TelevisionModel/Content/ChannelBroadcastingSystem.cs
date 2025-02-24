namespace TelevisionModel.Content;

public class ChannelBroadcastingSystem : IContentProvider
{
    private List<TelevisionChannel> AvailableChannels { get; set; }
    
    private int SelectedChannelIndex { get; set; }

    public ChannelBroadcastingSystem()
    {
        AvailableChannels = new List<TelevisionChannel>();
        SelectedChannelIndex = 0;
        
        try
        {
            AvailableChannels = SignalTransmitter.FindChannels();
        }
        catch (Exception e)
        {
            throw new FormatException("Failed to load television channels.");
        }
    }
    
    public ActionResult SwitchToNext()
    {
        //TODO add all checks
        SelectedChannelIndex = SelectedChannelIndex > AvailableChannels.Count ? 0 : SelectedChannelIndex + 1;
        return new ActionResult(AvailableChannels[SelectedChannelIndex].ToString());
    }

    public ActionResult SwitchToPrevious()
    {
        throw new NotImplementedException();
    }
}