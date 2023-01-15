using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponce<List<User>>>> GetUsers()
        {
            var result = await UserService.GetUsers();
            return Ok(result);
        }

        [HttpDelete("{userId}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponce<List<User>>>> DeleteUser(int userId)
        {
            var result = await UserService.DeleteUser(userId);
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponce<List<User>>>> AddUser(User user)
        {
            var result = await UserService.AddUser(user);
            return Ok(result);
        }
        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponce<List<User>>>> UpdateUser(User user)
        {
            var result = await UserService.UpdateUser(user);
            return Ok(result);
        }
    }
}
