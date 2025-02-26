using System.Text.Json;
using TelevisionModel.Content;
using TelevisionModel.Data;
using TelevisionModel.Data;
using TelevisionModel.Data;
using TelevisionModel.TelevisionSubsystems;

namespace TelevisionModel.Utils;

public static class Saver
{
    public static void SaveToFile(Television television)
    {
        string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.SaveFileName);
        File.WriteAllText(savePath, television.Specifications.ToJson());
    }

    public static Television TryLoadFromFile()
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.SaveFileName);
            string text = File.ReadAllText(path);
            TechnicalSpecifications specifications = JsonSerializer.Deserialize<TechnicalSpecifications>(text) 
                                                     ?? throw new JsonException();
            
            Screen screen = new Screen(Resources.ScreenMaxResX, Resources.ScreenMaxResY, Resources.ScreenDefaultMatrixType, 
                Resources.ScreenDefaultHeight, Resources.ScreenDefaultWidth);
            screen.ChangeResolution(specifications.ResolutionX, specifications.ResolutionY);
            
            SoundSystem soundSystem = new SoundSystem(Resources.SoundSystemDefaultPower);
            soundSystem.EditVolume(specifications.CurrentVolume);

            Software software = new Software(specifications.SoftwareVersion);
            ChannelBroadcastingSystem channelBroadcastingSystem = new ChannelBroadcastingSystem(specifications.SelectedChannelIndex);
            StreamingService streamingService = new StreamingService(specifications.SelectedTelevisionSeriesIndex);
            
            Television television = new Television(soundSystem, screen, software, channelBroadcastingSystem, streamingService, specifications.State);

            return television;
        }
        catch (Exception e)
        {
            SoundSystem soundSystem = new SoundSystem(Resources.SoundSystemDefaultPower);
            
            Screen screen = new Screen(Resources.ScreenMaxResX, Resources.ScreenMaxResY, Resources.ScreenDefaultMatrixType, 
                Resources.ScreenDefaultHeight, Resources.ScreenDefaultWidth);
            
            return new Television(soundSystem, screen);
        }
    }
}