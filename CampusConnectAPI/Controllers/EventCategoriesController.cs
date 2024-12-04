using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoriesController : ControllerBase
    {
        private readonly IEventCategoryService _eventCategoryService;

        public EventCategoriesController(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _eventCategoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateEventCategoryDTO eventCategoryDto)
        {
            var result = await _eventCategoryService.AddCategory(eventCategoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = result.CategoryID }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] EventCategoryDTO categoryDTO)
        {
            var result = await _eventCategoryService.UpdateCategory(categoryDTO);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            var result = await _eventCategoryService.RemoveCategory(categoryId);
            if (!result)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _eventCategoryService.GetCategoryById(categoryId);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
    }
}