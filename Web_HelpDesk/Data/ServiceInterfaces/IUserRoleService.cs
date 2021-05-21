using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public interface IUserRoleService
    {
        // Users Section
        Task<IEnumerable<string>> GetUserInRolesAsync(string Email);
        bool IsUserAuthenticated(ClaimsPrincipal currentUser);
        Task<bool> IsUserInRoleAsync(string email, string role);
        Task<IEnumerable<IdentityUser>> GetUsersInRoleAsync(string roleName);
        Task AddUserToRoleAsync(string email, string role);
        Task<IdentityResult> CreateNewUserAsync(string userName, string email, string password);
        IQueryable<IdentityUser> GetAllUsersAsync();
        Task<IdentityUser> GetUserIdentityAsync(string Email);
        Task RemoveUserFromRoleAsync(string email, string role);
        Task RemoveUserFromRolesAsync(string email, IEnumerable<string> roles);
        Task DisableUserAsync(string email);
        Task EnableUserAsync(string email);
        Task<string> GetUserStatusAsync(string email);
        Task SetInfifiteLockOutEndDate(string email);

        // Roles section
        Task<bool> DoesRoleExistAsync(string role);
        Task CreateNewRoleAsync(string role);
        Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
