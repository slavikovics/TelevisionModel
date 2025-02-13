using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Screen
    {
        public int ResolutionX { get; set; }
        
        public int ResolutionY { get; set; }
        
        public string MatrixType { get; set; }
        
        public double Height { get; set; }
        
        public double Width { get; set; }
        
        private bool IsTurnedOn { get; set; }

        public Screen(int resolutionX, int resolutionY, string matrixType, double height, double width)
        {
            IsTurnedOn = false;
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
            MatrixType = matrixType;
            Height = height;
            Width = width;
        }
    }
}
