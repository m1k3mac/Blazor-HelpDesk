using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models
{
    public class Status
    {
        [Key] public int StatusId { get; set; } // * refer to notes (VALUESandKEYS)
        public string TicketStatus { get; set; }
    }
}
