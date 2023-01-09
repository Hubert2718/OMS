using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.Server.Services.ClientService;

namespace OMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService ClientService;

        public ClientController(IClientService ClientService)
        {
            this.ClientService = ClientService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponce<List<Shared.Client>>>> GetClients()
        {
            var response = await ClientService.GetClientsAsync();
            return Ok(response);
        }
    }
}
