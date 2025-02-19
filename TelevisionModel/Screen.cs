using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelevisionModel.Data;

namespace TelevisionModel
{
    public class Screen
    {
        private int ResolutionX { get; set; }
        
        private int ResolutionY { get; set; }
        
        public int MaxResolutionX { get; }
        
        public int MaxResolutionY { get; }
        
        public string MatrixType { get; }
        
        public double Height { get; }
        
        public double Width { get; }
        
        private bool IsTurnedOn { get; set; }

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
                throw new ArgumentException(Resources.ResolutionRestrictionsErrorMessage);
            }

            if (newResolutionX < 0 || newResolutionY < 0)
            {
                throw new ArgumentException(Resources.ResolutionRestrictionsErrorMessage);
            }
            
            ResolutionX = newResolutionX;
            ResolutionY = newResolutionY;
        }

        public void TurnOn()
        {
            if (IsTurnedOn)
            {
                throw new InvalidOperationException(Resources.ScreenIsAlreadyTurnedOnErrorMessage);
            }
            
            IsTurnedOn = true;
        }

        public void TurnOff()
        {
            if (!IsTurnedOn)
            {
                throw new InvalidOperationException(Resources.ScreenIsNotTurnedOnErrorMessage);
            }
            
            IsTurnedOn = false;
        }

        public string BuildInfoString()
        {
            return $"Screen resolution: {ResolutionX} x {ResolutionY}. Matrix type: {MatrixType}. Height: {Height}. Width: {Width}";
        }
    }
}
