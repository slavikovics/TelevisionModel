using TelevisionModel.Data;
using TelevisionModel.Utils;

namespace TelevisionModel.Content;

public class ChannelBroadcastingSystem : IContentProvider
{
    public int SelectedChannelIndex { get; private set; }

    public TelevisionChannel SelectedChannel => AvailableChannels[SelectedChannelIndex];

    private List<TelevisionChannel> AvailableChannels { get; }

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
            throw new FormatException(Resources.FailedToLoadChannels);
        }
    }

    public ChannelBroadcastingSystem(int selectedChannelIndex) : this()
    {
        SelectedChannelIndex = selectedChannelIndex;
    }
    
    public ActionResult SwitchToNext()
    {
        if (AvailableChannels.Count == 0) return new ActionResult(Resources.FailedToLoadChannels);
        SelectedChannelIndex = SelectedChannelIndex > AvailableChannels.Count - 2 ? 0 : SelectedChannelIndex + 1;
        return new ActionResult(AvailableChannels[SelectedChannelIndex].ToString());
    }

    public ActionResult SwitchToPrevious()
    {
        if (AvailableChannels.Count == 0) return new ActionResult(Resources.FailedToLoadChannels);
        SelectedChannelIndex = SelectedChannelIndex == 0 ? AvailableChannels.Count - 1 : SelectedChannelIndex - 1;
        return new ActionResult(AvailableChannels[SelectedChannelIndex].ToString());
    }

    public ActionResult Greet()
    {
        ActionResult actionResult = new ActionResult(Resources.ChangedToTelevisionBroadcastingState);
        actionResult.MessageDetails.Add(Resources.AvailableChannels);
        
        foreach (var channel in AvailableChannels)
        {
            actionResult.MessageDetails.Add(channel.ToString() + Environment.NewLine);
        }
        
        actionResult.MessageDetails.Add("\n\n");
        actionResult.MessageDetails.Add(Resources.SelectedChannel);
        actionResult.MessageDetails.Add(AvailableChannels[SelectedChannelIndex].ToString());
        
        return actionResult;
    }
}