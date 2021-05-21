using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRoleService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Users Section ****************************************************************************************
        public async Task<IEnumerable<string>> GetUserInRolesAsync(string Email)
        {
            var userIdentity = await _userManager.FindByNameAsync(Email);
            var result = await _userManager.GetRolesAsync(userIdentity);
            return result;            
        }
        public async Task<IdentityUser> GetUserIdentityAsync(string Email)
        {
            //Get the users identity from an email address            
            var result = await _userManager.FindByNameAsync(Email);
            return result;
        }
        public bool IsUserAuthenticated(ClaimsPrincipal currentUser)
        {
            // Check if logged on user is authenticated: refer to notes [AUTHENTICATION and PAGES]
            if (!currentUser.Identity.IsAuthenticated)
                return false;
            else
                return true;
        }
        public async Task<bool> IsUserInRoleAsync(string email, string role)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            var result = await _userManager.IsInRoleAsync(userIdentity, role);
            return result;

            //if (currentUser.IsInRole(role))
            //    return true;
            //else
            //    return false;
        }

        public async Task<IEnumerable<IdentityUser>> GetUsersInRoleAsync(string roleName)
        {
            var result = await _userManager.GetUsersInRoleAsync(roleName);
            return result;
        }

        public async Task AddUserToRoleAsync(string email, string role)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            await _userManager.AddToRoleAsync(userIdentity, role);
        }

        public async Task<IdentityResult> CreateNewUserAsync(string userName, string email, string password)
        {
            var user = new IdentityUser { UserName = userName, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            return result; // will return result.Succeeded if successful or Password not complex enough etc.
        }

        public IQueryable<IdentityUser> GetAllUsersAsync()
        {
            return _userManager.Users;   
        }

        public async Task RemoveUserFromRoleAsync(string email, string role)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            await _userManager.RemoveFromRoleAsync(userIdentity, role);            
        }

        public async Task RemoveUserFromRolesAsync(string email, IEnumerable<string> roles)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            await _userManager.RemoveFromRolesAsync(userIdentity, roles);
        }

        public async Task DisableUserAsync(string email)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            await _userManager.SetLockoutEnabledAsync(userIdentity, true);
        }

        public async Task EnableUserAsync(string email)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            await _userManager.SetLockoutEnabledAsync(userIdentity, false);
        }

        public async Task SetInfifiteLockOutEndDate(string email)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            DateTime dateTime = new DateTime(9999, 1, 1, 1, 1, 1);
            await _userManager.SetLockoutEndDateAsync(userIdentity, dateTime);
        }

        public async Task<string> GetUserStatusAsync(string email)
        {
            var userIdentity = await _userManager.FindByNameAsync(email);
            bool status = await _userManager.IsLockedOutAsync(userIdentity);
            if (status)
                return "Disabled";
            else
                return "Enabled";
        }

        // Roles Section ****************************************************************************************
        public async Task<bool> DoesRoleExistAsync(string role)
        {
            var roleResult = await _roleManager.RoleExistsAsync(role);
            return roleResult;
        }

        public async Task CreateNewRoleAsync(string role)
        {
            await _roleManager.CreateAsync(new IdentityRole(role));
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            var result = await _roleManager.Roles.ToListAsync();

            // The next two line (could use either) is a temporary fix. There is no async for the above statement. I used this async method to await 
            // its execution else I get threading issues of more then one thread accessing the dbContext.
            //await Task.Delay(500);
            //var something = await _roleManager.RoleExistsAsync("Administrators"); 

            return result;
        }
    }
}
