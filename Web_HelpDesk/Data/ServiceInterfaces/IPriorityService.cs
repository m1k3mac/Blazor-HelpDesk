using Web_HelpDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public interface IPriorityService
    {
        Task<IEnumerable<Priority>> GetPrioritiesAsync();
    }
}
