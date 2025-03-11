using TelevisionModel.Content;
using TelevisionModel.Utils;

namespace TelevisionModelWebApp.Models;

public class StreamingModel
{
    public TelevisionSeries Series { get; set; }
    
    public TechnicalSpecifications Specifications { get; set; }

    public StreamingModel(TelevisionSeries series, TechnicalSpecifications specs)
    {
        Series = series;
        Specifications = specs;
    }
}