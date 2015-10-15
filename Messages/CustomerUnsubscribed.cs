using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class CustomerUnsubscribed
    {
        public string Name { get; set; }

        public CustomerUnsubscribed(string name)
        {
            Name = name;
        }
    }
}
