using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public string PriorityLevel { get; set; }
    }
}
