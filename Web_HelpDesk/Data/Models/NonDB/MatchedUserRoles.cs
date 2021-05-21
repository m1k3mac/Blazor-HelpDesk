using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models.NonDB
{
    public class MatchedUserRoles
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string GUID { get; set; }
        public string  RoleName { get; set; }
        public string Status { get; set; }
    }
}
