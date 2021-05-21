using Web_HelpDesk.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public class AdditionalCriteria : IAdditionalCriteria
    {
        private readonly ApplicationDbContext _dbContext;
        public AdditionalCriteria(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task AddAdditionalUserNotificationsAsync(AdditionalNotification notification)
        {
            var result = await _dbContext.AdditionalNotifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<AdditionalNotification>> GetAdditionalNotificationsByDeptAsync(string DepartmentName)
        {
            return await _dbContext.AdditionalNotifications.Include(d => d.Department).Include(u => u.UserDetail).Where(l => l.Department.DepartmentName == DepartmentName).ToListAsync();
        }

        public async Task<IEnumerable<AdditionalNotification>> GetAdditionalNotificationsByUserAsync(string Email)
        {
            return await _dbContext.AdditionalNotifications.Include(d => d.Department).Include(u => u.UserDetail).Where(l => l.UserDetail.Email == Email).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task RemoveAdditionalNotificationsAsync(IEnumerable<AdditionalNotification> notifications)
        {
            _dbContext.AdditionalNotifications.RemoveRange(notifications);
            await _dbContext.SaveChangesAsync();
        }
    }
}
