using AutoMapper;
using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;

namespace CampusConnect.Business.Service
{

    public class EventCategoryService : IEventCategoryService
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;
        private readonly IMapper _mapper;

        public EventCategoryService(IEventCategoryRepository eventCategoryRepository, IMapper mapper)
        {
            _eventCategoryRepository = eventCategoryRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<EventCategoryDTO>> GetAllCategories()
        {
            var categories = await _eventCategoryRepository.GetAllCategories();
            return _mapper.Map<IEnumerable<EventCategoryDTO>>(categories);
        }

        public async Task<EventCategoryDTO> AddCategory(CreateEventCategoryDTO eventCategoryDto)
        {
            var category = _mapper.Map<EventCategory>(eventCategoryDto);
            var result = await _eventCategoryRepository.AddCategory(category);
            return _mapper.Map<EventCategoryDTO>(result);
        }

        public async Task<EventCategoryDTO> UpdateCategory(EventCategoryDTO categoryDTO)
        {
            var existingCategory = await _eventCategoryRepository.GetCategoryById(categoryDTO.CategoryID);
            if (existingCategory == null)
                return null;

            _mapper.Map(categoryDTO, existingCategory);
            var result = await _eventCategoryRepository.UpdateCategory(existingCategory);
            return _mapper.Map<EventCategoryDTO>(result);
        }

        public async Task<bool> RemoveCategory(int categoryId)
        {
            return await _eventCategoryRepository.RemoveCategory(categoryId);
        }

        public async Task<EventCategoryDTO> GetCategoryById(int categoryId)
        {
            var category = await _eventCategoryRepository.GetCategoryById(categoryId);
            return _mapper.Map<EventCategoryDTO>(category);
        }
    }
}