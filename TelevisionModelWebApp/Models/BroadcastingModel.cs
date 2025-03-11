using TelevisionModel.Content;
using TelevisionModel.Utils;

namespace TelevisionModelWebApp.Models;

public class BroadcastingModel
{
    public TelevisionChannel Channel { get; set; }
    
    public TechnicalSpecifications Specifications { get; set; }

    public BroadcastingModel(TelevisionChannel channel, TechnicalSpecifications specs)
    {
        Channel = channel;
        Specifications = specs;
    }
}