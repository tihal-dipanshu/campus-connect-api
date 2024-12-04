using CampusConnect.Business.DTO;
using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.IService
{
    public interface IEventCategoryService
    {
        Task<EventCategoryDTO> AddCategory(CreateEventCategoryDTO eventCategoryDto);
        Task<EventCategoryDTO> UpdateCategory( EventCategoryDTO categoryDTO);
        Task<bool> RemoveCategory(int categoryId);
        Task<EventCategoryDTO> GetCategoryById(int categoryId);
        Task<IEnumerable<EventCategoryDTO>> GetAllCategories();
    }
}