using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class Device
    {
        public string Name { get; set; }

        public string Function { get; set; }

        public Device(string name, string function)
        {
            Name = name;
            Function = function;
        }
    }
}
