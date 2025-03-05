using System.Text.Json;
using TelevisionModel.Content;
using TelevisionModel.TelevisionSubsystems;

namespace TelevisionModel.Utils
{
    public class TechnicalSpecifications
    {
        public States State { get; set; }
        
        public int ResolutionX { get; set; }

        public int ResolutionY { get; set; } 

        public double CurrentVolume { get; set; } 

        public string SoftwareVersion { get; set; } 

        public int SelectedTelevisionSeriesIndex { get; set; }

        public int SelectedChannelIndex { get; set; }

        public TechnicalSpecifications(States state, Screen screen, SoundSystem soundSystem, Software software,
            ChannelBroadcastingSystem channelBroadcastingSystem, StreamingService streamingService)
        {
            State = state;
            ResolutionX = screen.ResolutionX;
            ResolutionY = screen.ResolutionY;
            CurrentVolume = soundSystem.Volume;
            SoftwareVersion = software.InstalledVersion;
            SelectedChannelIndex = channelBroadcastingSystem.SelectedChannelIndex;
            SelectedTelevisionSeriesIndex = streamingService.SelectedIndex;
        }

        public TechnicalSpecifications()
        {
        }
        
        public override string ToString()
        {
            string result = "System info:\n";
            result += $"State: {State}\n";
            result += $"ResolutionX: {ResolutionX}\n";
            result += $"ResolutionY: {ResolutionY}\n";
            result += $"Current volume: {CurrentVolume}\n";
            result += $"Software version: {SoftwareVersion}\n";
            result += $"Selected streaming: {SelectedTelevisionSeriesIndex}\n";
            result += $"Selected channel: {SelectedChannelIndex}\n";
            return result;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Update(States state, Screen screen, SoundSystem soundSystem, Software software,
            ChannelBroadcastingSystem channelBroadcastingSystem, StreamingService streamingService)
        {
            State = state;
            ResolutionX = screen.ResolutionX;
            ResolutionY = screen.ResolutionY;
            CurrentVolume = soundSystem.Volume;
            SoftwareVersion = software.InstalledVersion;
            SelectedChannelIndex = channelBroadcastingSystem.SelectedChannelIndex;
            SelectedTelevisionSeriesIndex = streamingService.SelectedIndex;
        }
    }
}
