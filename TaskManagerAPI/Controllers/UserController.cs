using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.Models;
using TaskManager.Services.Interface;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserModel> userModels = await _userService.GetAllUsers();
            return Ok(userModels);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetByUserId(int UserId)
        {
            var user = await _userService.GetByUserId(UserId); //can write if(user==null) return NotFound()
            return Ok(user);
        }
        //for post we pass usermodel as a parameter 
        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel um)
        {
            var newUser = await _userService.AddUser(um);
            return Ok(newUser);
        }
        [HttpDelete("DeleteUser/{UserId}")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var res = await _userService.DeleteUser(UserId);
            if (res == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
