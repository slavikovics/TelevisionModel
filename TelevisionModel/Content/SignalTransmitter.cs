using System.Text.Json;
using TelevisionModel.Data;

namespace TelevisionModel.Content;

public static class SignalTransmitter
{
    private static readonly List<TelevisionChannel> AvailableChannels = new List<TelevisionChannel>();
    
    private static readonly List<TelevisionSeries> AvailableSeries = new List<TelevisionSeries>();
    
    private static void AddTelevisionChannel(string channelName, string? logoPath)
    {
        if (logoPath is null) return;
            
        foreach (TelevisionChannel channel in AvailableChannels)
        {
            if (channel.Name == channelName) throw new ArgumentException($"{Resources.ChannelWithTheSameNameAlreadyExistsErrorMessage} " +
                                                                         $"Name: {channelName}.");
        }
            
        TelevisionChannel televisionChannel = new TelevisionChannel(logoPath, channelName);
        AvailableChannels.Add(televisionChannel);
    }

    private static void RemoveTelevisionChannel(string channelName)
    {
        TelevisionChannel? channelToRemove = AvailableChannels.Find(channel => channel.Name == channelName);
        if (channelToRemove is null) throw new ArgumentException(Resources.TelevisionChannelDoesNotExistErrorMessage);

        AvailableChannels.Remove(channelToRemove);
    }
    
    public static List<TelevisionChannel> FindChannels()
    {
        string text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.ChannelsDataRelativePath));
        JsonDocument jsonDocument = JsonDocument.Parse(text);

        foreach (var property in jsonDocument.RootElement.EnumerateObject())
        {
            AddTelevisionChannel(property.Name, property.Value.GetString());
        }
        
        return AvailableChannels;
    }

    public static List<TelevisionSeries> FindSeries()
    {
        string text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.TelevisionSeriesPath));
        JsonDocument jsonDocument = JsonDocument.Parse(text);
        
        foreach (var element in jsonDocument.RootElement.EnumerateArray())
        {
            element.TryGetProperty("url", out JsonElement urlElement);
            element.TryGetProperty("name", out JsonElement nameElement);
            element.TryGetProperty("summary", out JsonElement summaryElement);
            element.TryGetProperty("image", out JsonElement imageElement);
            imageElement.TryGetProperty("medium", out JsonElement linkElement);
            
            string? url = urlElement.GetString();
            string? name = nameElement.GetString();
            string? summary = summaryElement.GetString();
            string? imageUrl = linkElement.GetString();
            
            if (url is null || name is null || summary is null || imageUrl is null) continue;
            
            AvailableSeries.Add(new TelevisionSeries(name, url, imageUrl, summary));
        }
        
        return AvailableSeries;
    }
}