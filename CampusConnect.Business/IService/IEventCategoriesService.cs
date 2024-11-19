using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.IService
{
    public interface IEventCategoriesService
    {
        Task<IEnumerable<EventCategory>> GetAllCategories();
        Task<EventCategory> GetCategoryById(int categoryId);
        Task<EventCategory> CreateCategory(EventCategory newCategory);
        Task UpdateCategory(int categoryId, EventCategory updateCategory);
        Task DeleteCategory(int categoryId);
        Task<IEnumerable<EventCategory>> SearchCategories(string searchTerm);
        Task<bool> IsCategoryNameTaken(string categoryName);
    }
}