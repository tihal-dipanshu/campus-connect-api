using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.IRepositories
{
    public interface IEventCategoryRepository
    {
        Task<EventCategory> AddCategory(EventCategory category);
        Task<EventCategory> UpdateCategory(EventCategory category);
        Task<bool> RemoveCategory(int categoryId);
        Task<EventCategory> GetCategoryById(int categoryId);
        Task<IEnumerable<EventCategory>> GetAllCategories();
    }
}