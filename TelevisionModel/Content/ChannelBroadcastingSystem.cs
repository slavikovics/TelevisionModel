namespace TelevisionModel.Content;

public class ChannelBroadcastingSystem : IContentProvider
{
    private List<TelevisionChannel> AvailableChannels { get; set; }
    
    private int SelectedChannel { get; set; }

    public ChannelBroadcastingSystem()
    {
        AvailableChannels = new List<TelevisionChannel>();
        SelectedChannel = 0;
        AvailableChannels = SignalTransmitter.FindChannels();
    }
    
    public ActionResult SwitchToNext()
    {
        throw new NotImplementedException();
    }

    public ActionResult SwitchToPrevious()
    {
        throw new NotImplementedException();
    }
}