using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class TelevisionChanel
    {
        public int Id { get; }
        
        public string Name { get; }

        public TelevisionChanel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
