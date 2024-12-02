using CampusConnect.Business.Entities;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _usersService.GetUserByUsername(username);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("role/{role}")]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            var users = await _usersService.GetUsersByRole(role);
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            if (newUser == null)
                return BadRequest();

            var createdUser = await _usersService.CreateUser(newUser);
            return CreatedAtAction(nameof(GetUserByUsername), new { username = createdUser.Username }, createdUser);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] User updateUser)
        {
            if (updateUser == null)
                return BadRequest();

            try
            {
                await _usersService.UpdateUser(userId, updateUser);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _usersService.DeleteUser(userId);
            return NoContent();
        }

        [HttpGet("check-username/{username}")]
        public async Task<IActionResult> IsUsernameTaken(string username)
        {
            var isTaken = await _usersService.IsUsernameTaken(username);
            return Ok(isTaken);
        }

        [HttpGet("check-email/{email}")]
        public async Task<IActionResult> IsEmailTaken(string email)
        {
            var isTaken = await _usersService.IsEmailTaken(email);
            return Ok(isTaken);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromQuery] string searchTerm)
        {
            var users = await _usersService.SearchUsers(searchTerm);
            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
                return BadRequest();

            try
            {
                var user = await _usersService.LoginUser(loginModel.Username, loginModel.Password);
                // Here you would typically generate a JWT token and return it
                // For simplicity, we're just returning the user object
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

