using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteersController(IVolunteerService volunteerService)
        {
            //_volunteerService = volunteerService;
            _volunteerService = volunteerService ?? throw new ArgumentNullException(nameof(volunteerService));
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetVolunteersByEventId(int eventId)
        {
            var volunteers = await _volunteerService.GetVolunteersByEventId(eventId);
            return Ok(volunteers);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVolunteers()
        {
            var volunteers = await _volunteerService.GetAllVolunteers();
            return Ok(volunteers);
        }

        // [HttpPost]
        // public async Task<IActionResult> AddVolunteer([FromBody] CreateVolunteerDTO volunteerDTO)
        // {
        //     var result = await _volunteerService.AddVolunteer(volunteerDTO);
        //     return CreatedAtAction(nameof(GetVolunteersByEventId), new { eventId = result.EventID }, result);
        // }

        [HttpDelete("{volunteerId}")]
        public async Task<IActionResult> RemoveVolunteer(int volunteerId)
        {
            var result = await _volunteerService.RemoveVolunteer(volunteerId);
            if (!result)
                return NotFound();
            return NoContent();
        }
        
        // [HttpPost]
        // public async Task<IActionResult> AddVolunteer([FromBody] CreateVolunteerDTO volunteerDTO)
        // {
        //     var result = await _volunteerService.AddVolunteer(volunteerDTO);
        //     return CreatedAtAction(nameof(GetVolunteersByEventId), new { eventId = result.Event.EventID }, result);
        // }
        
        [HttpPost]
        public async Task<IActionResult> AddVolunteer([FromBody] CreateVolunteerDTO volunteerDTO)
        {
            if (volunteerDTO == null)
            {
                return BadRequest("Volunteer data is required.");
            }

            var result = await _volunteerService.AddVolunteer(volunteerDTO);
            if (result == null)
            {
                return StatusCode(500, "An error occurred while adding the volunteer.");
            }
            return CreatedAtAction(nameof(GetVolunteersByEventId), new { eventId = result.EventID }, result);
        }

        [HttpPut("{volunteerId}/approve")]
        public async Task<IActionResult> ApproveVolunteer(int volunteerId)
        {
            var result = await _volunteerService.ApproveVolunteer(volunteerId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{volunteerId}/reject")]
        public async Task<IActionResult> RejectVolunteer(int volunteerId)
        {
            var result = await _volunteerService.RejectVolunteer(volunteerId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}