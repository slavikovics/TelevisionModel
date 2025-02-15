using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Device
    {
        public string Name { get; }

        public string Function { get; }

        public Device(string name, string function)
        {
            Name = name;
            Function = function;
        }
    }
}
