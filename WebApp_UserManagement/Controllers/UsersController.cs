using Microsoft.AspNetCore.Mvc;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Model;
using UserManagement.Shared.Contracts;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> Get()
        {
            var users = await _userManager.GetUserAsync();
            return Ok(users);
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userManager.AddUserAsync(user);
            return Ok();
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            await _userManager.EditUserAsync(user);
            return Ok();
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            await _userManager.DeleteUserAsync(userId);
            return Ok();
        }
    }
}
