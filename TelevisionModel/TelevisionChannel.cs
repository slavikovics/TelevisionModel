using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class TelevisionChannel
    {
        public int Id { get; }
        
        public string Name { get; }

        public TelevisionChannel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
