using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; } // * refer to notes (VALUESandKEYS)
        public DateTime Logged { get; set; }
        public string Creator { get; set; }
        public string Subject { get; set; }
        public int PriorityId { get; set; } // for navprop
        public int StatusId { get; set; } // for navprop
        public string Assignee { get; set; }
        public string EmailAddress { get; set; }
        public string Department { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string AltContactNumber { get; set; }
        public Priority Priority { get; set; } // * refer to notes (NAVPROP) for this and below
        public Status Status { get; set; }
    }
}
