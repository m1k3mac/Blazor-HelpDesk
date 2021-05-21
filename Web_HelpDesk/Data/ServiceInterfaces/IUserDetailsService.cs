using Web_HelpDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public interface IUserDetailsService
    {
        Task<UserDetail> GetUserDetailsAsync(string email);
        Task AddUserDetailsAsync(UserDetail userDetails);
        Task<IEnumerable<UserDetail>> GetAllUserDetailsAsync();
        Task UpdateUserDetailsAsync(string Email, string FirstName, string LastName);
    }
}
