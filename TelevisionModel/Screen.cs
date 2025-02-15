using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Screen
    {
        public int ResolutionX { get; private set; }
        
        public int ResolutionY { get; private set; }
        
        public int MaxResolutionX { get; }
        
        public int MaxResolutionY { get; }
        
        public string MatrixType { get; }
        
        public double Height { get; }
        
        public double Width { get; }
        
        public bool IsTurnedOn { get; private set; }

        public Screen(int maxResolutionX, int maxResolutionY, string matrixType, double height, double width)
        {
            IsTurnedOn = false;
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
                throw new ArgumentException("Resolution must be between 0 and MaxResolution");
            }

            if (newResolutionX < 0 || newResolutionY < 0)
            {
                throw new ArgumentException("Resolution must be between 0 and MaxResolution");
            }
            
            ResolutionX = newResolutionX;
            ResolutionY = newResolutionY;
        }

        public void TurnOn()
        {
            if (IsTurnedOn)
            {
                throw new InvalidOperationException("The screen is already turned on");
            }
            
            IsTurnedOn = true;
        }

        public void TurnOff()
        {
            if (!IsTurnedOn)
            {
                throw new InvalidOperationException("The screen is not turned on");
            }
            
            IsTurnedOn = false;
        }

        public string BuildInfoString()
        {
            return $"Screen resolution: {ResolutionX} x {ResolutionY}. Matrix type: {MatrixType}. Height: {Height}. Width: {Width}";
        }
    }
}
