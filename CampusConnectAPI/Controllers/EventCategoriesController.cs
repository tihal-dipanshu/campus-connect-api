using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoriesController : Controller
    {
        private readonly IEventCategoriesService _eventCategoriesService;

        public EventCategoriesController(IEventCategoriesService eventCategoriesService)
        {
            _eventCategoriesService = eventCategoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _eventCategoriesService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _eventCategoriesService.GetCategoryById(categoryId);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] EventCategory newCategory)
        {
            if (newCategory == null)
                return BadRequest();

            var createdCategory = await _eventCategoriesService.CreateCategory(newCategory);
            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createdCategory.CategoryID }, createdCategory);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] EventCategory updateCategory)
        {
            if (updateCategory == null)
                return BadRequest();

            try
            {
                await _eventCategoriesService.UpdateCategory(categoryId, updateCategory);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                await _eventCategoriesService.DeleteCategory(categoryId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCategories([FromQuery] string searchTerm)
        {
            var categories = await _eventCategoriesService.SearchCategories(searchTerm);
            return Ok(categories);
        }
    }
}