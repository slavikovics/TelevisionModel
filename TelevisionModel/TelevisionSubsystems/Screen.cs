using TelevisionModel.Data;

namespace TelevisionModel.TelevisionSubsystems
{
    public class Screen
    {
        public int ResolutionX { get; private set; }
        
        public int ResolutionY { get; private set; }
        
        private int MaxResolutionX { get; }
        
        private int MaxResolutionY { get; }
        
        private string MatrixType { get; }
        
        private double Height { get; }
        
        private double Width { get; }

        public Screen(int maxResolutionX, int maxResolutionY, string matrixType, double height, double width)
        {
            ResolutionX = maxResolutionX;
            ResolutionY = maxResolutionY;
            MaxResolutionX = maxResolutionX;
            MaxResolutionY = maxResolutionY;
            MatrixType = matrixType;
            Height = height;
            Width = width;
        }

        public void ChangeResolution(int newResolutionX, int newResolutionY)
        {
            if (newResolutionX > MaxResolutionX || newResolutionY > MaxResolutionY)
            {
                throw new ArgumentException(Resources.ResolutionRestrictionsErrorMessage + $" (MaxResolutionX: {MaxResolutionX})");
            }

            if (newResolutionX < 0 || newResolutionY < 0)
            {
                throw new ArgumentException(Resources.ResolutionRestrictionsErrorMessage + $" (MaxResolutionY: {MaxResolutionY})");
            }
            
            ResolutionX = newResolutionX;
            ResolutionY = newResolutionY;
        }

        public string BuildInfoString()
        {
            return $"Screen resolution: {ResolutionX} x {ResolutionY}. Matrix type: {MatrixType}. Height: {Height}. Width: {Width}";
        }
    }
}
