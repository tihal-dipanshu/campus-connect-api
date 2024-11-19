using AutoMapper;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.Service
{
    public class EventCategoriesService : IEventCategoriesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork.IUnitOfWork _unitOfWork;

        public EventCategoriesService(IMapper mapper, IUnitOfWork.IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventCategory>> GetAllCategories()
        {
            var categories = await _unitOfWork.EventCategoriesRepository.GetAllCategories();
            return _mapper.Map<IEnumerable<EventCategory>>(categories);
        }

        public async Task<EventCategory> GetCategoryById(int categoryId)
        {
            var category = await _unitOfWork.EventCategoriesRepository.GetCategoryById(categoryId);
            return _mapper.Map<EventCategory>(category);
        }

        public async Task<EventCategory> CreateCategory(EventCategory newCategory)
        {
            var category = _mapper.Map<EventCategory>(newCategory);
            await _unitOfWork.EventCategoriesRepository.CreateCategory(category);
            _unitOfWork.Save();

            return _mapper.Map<EventCategory>(category);
        }

        public async Task UpdateCategory(int categoryId, EventCategory updateCategory)
        {
            var category = await _unitOfWork.EventCategoriesRepository.GetCategoryById(categoryId);
            if (category == null)
                throw new KeyNotFoundException("Category not found");

            _mapper.Map(updateCategory, category);

            await _unitOfWork.EventCategoriesRepository.UpdateCategory(category);
            _unitOfWork.Save();
        }

        public async Task DeleteCategory(int categoryId)
        {
            await _unitOfWork.EventCategoriesRepository.DeleteCategory(categoryId);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<EventCategory>> SearchCategories(string searchTerm)
        {
            var categories = await _unitOfWork.EventCategoriesRepository.SearchCategories(searchTerm);
            return _mapper.Map<IEnumerable<EventCategory>>(categories);
        }

        public async Task<bool> IsCategoryNameTaken(string categoryName)
        {
            return await _unitOfWork.EventCategoriesRepository.IsCategoryNameTaken(categoryName);
        }
    }
}