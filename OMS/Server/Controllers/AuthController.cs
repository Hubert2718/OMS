using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace OMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponce<int>>> Register(UserRegister request)
        {
            var response = await authService.Register(new Shared.User { Email = request.Email }, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponce<string>>> Login(UserLogin request)
        {
            var response = await authService.Login(request.Email, request.Password); 
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponce<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await authService.ChangePassword(int.Parse(userId), newPassword);

            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

    }
}
