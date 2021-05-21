using Web_HelpDesk.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public class PriorityService : IPriorityService
    {
        private readonly ApplicationDbContext _dbContext;
        public PriorityService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Priority>> GetPrioritiesAsync()
        {
            var results = await _dbContext.Priorities.ToListAsync();
            return results;
        }
    }
}
