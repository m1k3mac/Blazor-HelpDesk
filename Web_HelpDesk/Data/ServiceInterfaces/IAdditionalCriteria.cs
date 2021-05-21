using Web_HelpDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_HelpDesk.Data
{
    public interface IAdditionalCriteria
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<AdditionalNotification>> GetAdditionalNotificationsByDeptAsync(string DepartmenName);
        Task<IEnumerable<AdditionalNotification>> GetAdditionalNotificationsByUserAsync(string Email);
        Task AddAdditionalUserNotificationsAsync(AdditionalNotification notification);
        Task RemoveAdditionalNotificationsAsync(IEnumerable<AdditionalNotification> notifications);
    }
}
