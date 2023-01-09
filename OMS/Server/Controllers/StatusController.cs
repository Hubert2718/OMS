using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService statusService;

        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponce<List<Status>>>> GetStatusList()
        {
            var result = await statusService.GetStatus();
            return Ok(result);
        }
    }
}
