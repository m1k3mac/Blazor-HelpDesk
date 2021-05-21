using Web_HelpDesk.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public class UserDetailsService : IUserDetailsService
    {
        public readonly ApplicationDbContext _dbContext;

        public UserDetailsService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task AddUserDetailsAsync(UserDetail userDetails)
        {
            await _dbContext.UserDetails.AddAsync(userDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserDetail> GetUserDetailsAsync(string email)
        {
            var result = await _dbContext.UserDetails.FirstOrDefaultAsync(u => u.Email == email);
            return result;
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetailsAsync()
        {
            var result = await _dbContext.UserDetails.OrderBy(l => l.Email).ToListAsync();
            return result;
        }
        public async Task UpdateUserDetailsAsync(string Email, string FirstName, string LastName)
        {
            var userDetail = await _dbContext.UserDetails.FirstOrDefaultAsync(u => u.Email == Email);
            userDetail.FirstName = FirstName;
            userDetail.LastName = LastName;
            await _dbContext.SaveChangesAsync();
        }
    }
}
