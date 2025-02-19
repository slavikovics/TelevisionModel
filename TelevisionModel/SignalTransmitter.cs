using System.Text.Json;
using TelevisionModel.Data;

namespace TelevisionModel;

public static class SignalTransmitter
{
    private static List<TelevisionChannel> _availableChannels = new List<TelevisionChannel>();
    
    private static void AddTelevisionChannel(string channelName, string? logoPath)
    {
        if (logoPath is null) return;
            
        foreach (TelevisionChannel channel in _availableChannels)
        {
            if (channel.Name == channelName) throw new ArgumentException($"{Resources.ChannelWithTheSameNameAlreadyExistsErrorMessage} " +
                                                                         $"Name: {channelName}.");
        }
            
        TelevisionChannel televisionChannel = new TelevisionChannel(logoPath, channelName);
        _availableChannels.Add(televisionChannel);
    }

    private static void RemoveTelevisionChannel(string channelName)
    {
        TelevisionChannel? channelToRemove = _availableChannels.Find(channel => channel.Name == channelName);
        if (channelToRemove is null) throw new ArgumentException(Resources.TelevisionChannelDoesNotExistErrorMessage);

        _availableChannels.Remove(channelToRemove);
    }
    
    public static List<TelevisionChannel> FindChannels()
    {
        string text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.ChannelsDataRelativePath));
        JsonDocument jsonDocument = JsonDocument.Parse(text);

        foreach (var property in jsonDocument.RootElement.EnumerateObject())
        {
            AddTelevisionChannel(property.Name, property.Value.GetString());
        }
        
        return _availableChannels;
    }
}