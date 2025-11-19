using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Kernal.Bus
{
    public class Event
    {
        public string AggregateID { get; set; }
        public DateTime TimeStamp { get; protected set; } = DateTime.UtcNow;
        
    }
}
