using CampusConnect.Business.IService;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventOrganizersController : ControllerBase
    {
        private readonly IEventOrganizerService _eventOrganizerService;

        public EventOrganizersController(IEventOrganizerService eventOrganizerService)
        {
            _eventOrganizerService = eventOrganizerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventOrganizers()
        {
            var organizers = await _eventOrganizerService.GetAllEventOrganizers();
            return Ok(organizers);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetOrganizersByEventId(int eventId)
        {
            var organizers = await _eventOrganizerService.GetOrganizersByEventId(eventId);
            return Ok(organizers);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrganizerById(int userId)
        {
            var organizer = await _eventOrganizerService.GetOrganizerById(userId);
            if (organizer == null)
                return NotFound();
            return Ok(organizer);
        }

        [HttpGet("user/{userId}/events")]
        public async Task<IActionResult> GetEventsByOrganizerId(int userId)
        {
            var events = await _eventOrganizerService.GetEventsByOrganizerId(userId);
            return Ok(events);
        }
    }
}