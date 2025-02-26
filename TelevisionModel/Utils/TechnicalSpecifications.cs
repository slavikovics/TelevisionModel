using System.Text.Json;
using TelevisionModel.Content;

namespace TelevisionModel.Utils
{
    public class TechnicalSpecifications(
        Screen screen,
        SoundSystem soundSystem,
        Software software,
        States state,
        ChannelBroadcastingSystem channelBroadcastingSystem,
        StreamingService streamingService)
    {
        private States State { get; set; } = state;
        private int ResolutionX { get; set; } = screen.MaxResolutionX;

        private int ResolutionY { get; set; } = screen.MaxResolutionY;

        private double CurrentVolume { get; set; } = soundSystem.Volume;

        private string SoftwareVersion { get; set; } = software.InstalledVersion;

        private int SelectedTelevisionSeriesIndex { get; set; } = streamingService.SelectedIndex;

        private double SelectedChannelIndex { get; set; } = channelBroadcastingSystem.SelectedChannelIndex;

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
            ResolutionX = screen.MaxResolutionX;
            ResolutionY = screen.MaxResolutionY;
            CurrentVolume = soundSystem.Volume;
            SoftwareVersion = software.InstalledVersion;
            SelectedChannelIndex = channelBroadcastingSystem.SelectedChannelIndex;
            SelectedTelevisionSeriesIndex = streamingService.SelectedIndex;
        }
    }
}
