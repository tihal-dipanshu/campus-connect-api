using CampusConnect.Business.IService;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventAttendeesController : ControllerBase
    {
        private readonly IEventAttendeeService _eventAttendeeService;

        public EventAttendeesController(IEventAttendeeService eventAttendeeService)
        {
            _eventAttendeeService = eventAttendeeService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAttendee(int eventId, int userId)
        {
            var result = await _eventAttendeeService.AddAttendee(eventId, userId);
            return Ok(result);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveAttendee(int eventId, int userId)
        {
            await _eventAttendeeService.RemoveAttendee(eventId, userId);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendees()
        {
            var attendees = await _eventAttendeeService.GetAllAttendees();
            return Ok(attendees);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetAttendeesByEventId(int eventId)
        {
            var attendees = await _eventAttendeeService.GetAttendeesByEventId(eventId);
            return Ok(attendees);
        }

        [HttpGet("user/{userId}/events")]
        public async Task<IActionResult> GetEventsByUserId(int userId)
        {
            var events = await _eventAttendeeService.GetEventsByUserId(userId);
            return Ok(events);
        }
    }
}