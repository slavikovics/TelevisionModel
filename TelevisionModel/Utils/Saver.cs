using System.Text.Json;
using TelevisionModel.Data;
using TelevisionModel.Data;
using TelevisionModel.Data;

namespace TelevisionModel.Utils;

public static class Saver
{
    public static void SaveToFile(Television television)
    {
        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.SaveFileName), JsonSerializer.Serialize(television));
    }

    public static Television TryLoadFromFile()
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.SaveFileName);
            string text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Television>(text) ?? throw new JsonException();
        }
        catch (Exception e)
        {
            SoundSystem soundSystem = new SoundSystem(Resources.SoundSystemDefaultPower);
            
            Screen screen = new Screen(Resources.ScreenDefaultResX, Resources.ScreenDefaultResY, Resources.ScreenDefaultMatrixType, 
                Resources.ScreenDefaultHeight, Resources.ScreenDefaultWidth);
            
            return new Television(soundSystem, screen);
        }
    }
}