using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string GUID { get; set; }
    }
}
