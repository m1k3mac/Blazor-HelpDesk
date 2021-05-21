using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models.NonDB
{
    public class ResponseTimes
    {
        public int TicketId { get; set; }
        public DateTime Logged { get; set; }
        public DateTime Claimed { get; set; }
        public DateTime Closed { get; set; }
    }
}
