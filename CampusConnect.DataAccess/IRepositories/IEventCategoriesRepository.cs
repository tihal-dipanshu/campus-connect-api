using CampusConnect.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.IRepositories
{
    public interface IEventCategoriesRepository : IRepository<EventCategory>
    {
        Task<IEnumerable<EventCategory>> GetAllCategories();
        Task<EventCategory> GetCategoryById(int categoryId);
        Task<EventCategory> GetCategoryByName(string categoryName);
        Task<bool> IsCategoryNameTaken(string categoryName);
        Task<EventCategory> CreateCategory(EventCategory category);
        Task UpdateCategory(EventCategory category);
        Task DeleteCategory(int categoryId);
        Task<IEnumerable<EventCategory>> SearchCategories(string searchTerm);
    }
}
