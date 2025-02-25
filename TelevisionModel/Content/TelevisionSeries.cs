namespace TelevisionModel.Content;

public class TelevisionSeries(string name, string url, string imageUrl, string summary)
{
    public string Name { get; set; } = name;

    public string Url { get; set; } = url;

    public string ImageUrl { get; set; } = imageUrl;

    public string Summary { get; set; } = summary;

    public override string ToString()
    {
        return $"Name: {Name}\nUrl: {Url}\nImageUrl: {ImageUrl}\nSummary: {Summary}";
    }
}