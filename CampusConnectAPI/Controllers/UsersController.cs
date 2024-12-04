using CampusConnect.Business.DTO;
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
        
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _usersService.GetUserById(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO newUser)
        {
            try
            {
                var createdUser = await _usersService.CreateUser(newUser);
                return CreatedAtAction(nameof(GetUserById), new { userId = createdUser.UserID }, createdUser);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserAccountInfoDTO updateUser)
        {
            if (updateUser == null)
                return BadRequest();

            try
            {
                await _usersService.UpdateUser(updateUser);
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

