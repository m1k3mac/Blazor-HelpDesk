using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data.Models
{
    public class AdditionalNotification
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int UserDetailId { get; set; }
        public Department Department { get; set; }
        public UserDetail UserDetail { get; set; }
    }
}
