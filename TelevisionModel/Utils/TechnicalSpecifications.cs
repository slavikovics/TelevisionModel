using System.Text.Json;

namespace TelevisionModel.Utils
{
    public class TechnicalSpecifications
    {
        private int ScreenMaxResolutionX { get; }
        
        private int ScreenMaxResolutionY { get; }
        
        public string ScreenMatrixType { get; }
        
        public double ScreenHeight { get; }
        
        public double ScreenWidth { get; }
        
        public double SoundSystemPower { get; }
        
        public TechnicalSpecifications(Screen screen, SoundSystem soundSystem)
        {
            ScreenMaxResolutionX = screen.MaxResolutionX;
            ScreenMaxResolutionY = screen.MaxResolutionY;   
            ScreenMatrixType = screen.MatrixType;
            ScreenHeight = screen.Height;
            ScreenWidth = screen.Width;
            SoundSystemPower = soundSystem.Power;

            string json = JsonSerializer.Serialize(screen);
            Console.WriteLine(json);
        }
    }
}
