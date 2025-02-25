using System.Text.Json;

namespace TelevisionModel.Utils
{
    public class TechnicalSpecifications(
        Screen screen,
        SoundSystem soundSystem,
        Software software,
        States state,
        int selectedChannel,
        int selectedStreaming)
    {
        public States State { get; } = state;
        public int ResolutionX { get; } = screen.MaxResolutionX;

        public int ResolutionY { get; } = screen.MaxResolutionY;

        public double CurrentVolume { get; } = soundSystem.Volume;

        public string SoftwareVersion { get; } = software.InstalledVersion;

        public int SelectedTelevisionSeriesIndex { get; } = selectedStreaming;

        public double SelectedChannelIndex { get; } = selectedChannel;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
