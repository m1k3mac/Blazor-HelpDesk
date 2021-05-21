using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models
{
    public class TicketDetail
    {
        public int Id { get; set; }        
        public string Comments { get; set; }
        public DateTime DateTime { get; set; }
        public int TicketId { get; set; }
    }
}
