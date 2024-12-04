using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventsService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var eventItem = await _eventsService.GetEventById(eventId);
            if (eventItem == null)
                return NotFound();
            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO createEventDTO)
        {
            if (createEventDTO == null)
                return BadRequest();

            var createdEvent = await _eventsService.CreateEvent(createEventDTO);
            return CreatedAtAction(nameof(GetEventById), new { eventId = createdEvent.EventID }, createdEvent);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventDTO updateEventDTO)
        {
            if (updateEventDTO == null)
                return BadRequest();

            try
            {
                await _eventsService.UpdateEvent(updateEventDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            try
            {
                await _eventsService.DeleteEvent(eventId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetEventsByCategory(int categoryId)
        {
            var events = await _eventsService.GetEventsByCategory(categoryId);
            return Ok(events);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchEvents([FromQuery] string searchTerm)
        {
            var events = await _eventsService.SearchEvents(searchTerm);
            return Ok(events);
        }
    }
}