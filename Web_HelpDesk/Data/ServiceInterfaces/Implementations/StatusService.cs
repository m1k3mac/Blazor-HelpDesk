using Web_HelpDesk.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _dbContext;

        public StatusService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Status>> GetStatusesAsync()
        {
            var results = await _dbContext.Statuses.ToListAsync();
            return results;
        }
    }
}
