using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelevisionModel
{
    public class TelevisionChannel
    {
        public bool IsPaidBuySubscription { get; }
        
        public string Name { get; }

        public TelevisionChannel(bool isPaidBuySubscription, string name)
        {
            IsPaidBuySubscription = isPaidBuySubscription;
            Name = name;
        }
    }
}
