using TelevisionModel.Data;
using TelevisionModel.Utils;

namespace TelevisionModel.Content;

public class StreamingService : IContentProvider
{
    public int SelectedIndex { get; private set; }
    
    public List<TelevisionSeries> Series { get; private set; }

    public StreamingService()
    {
        SelectedIndex = 0;
        Series = new List<TelevisionSeries>();
        
        try
        {
            Series = SignalTransmitter.FindSeries();
        }
        catch (Exception e)
        {
            throw new FormatException(Resources.FailedToLoadSeries);
        }
    }

    public StreamingService(int selectedIndex) : this()
    {
        SelectedIndex = selectedIndex;
    }

    public ActionResult SwitchToNext()
    {
        if (Series.Count == 0) return new ActionResult(Resources.FailedToLoadSeries);
        SelectedIndex = SelectedIndex > Series.Count - 2 ? 0 : SelectedIndex + 1;
        return new ActionResult(Series[SelectedIndex].ToString());
    }

    public ActionResult SwitchToPrevious()
    {
        if (Series.Count == 0) return new ActionResult(Resources.FailedToLoadSeries);
        SelectedIndex = SelectedIndex == 0 ? Series.Count - 1 : SelectedIndex - 1;
        return new ActionResult(Series[SelectedIndex].ToString());
    }
    
    public ActionResult Greet()
    {
        ActionResult actionResult = new ActionResult(Resources.ChangedToStreamingState);
        actionResult.MessageDetails.Add("Available series:");
        
        foreach (var series in Series)
        {
            actionResult.MessageDetails.Add(series.ToString() + Environment.NewLine);
        }
        
        actionResult.MessageDetails.Add("\n\n");
        actionResult.MessageDetails.Add("Selected series:");
        actionResult.MessageDetails.Add(Series[SelectedIndex].ToString());
        
        return actionResult;
    }
}