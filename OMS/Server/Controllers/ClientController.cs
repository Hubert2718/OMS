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

        [HttpPost]
        public async Task<ActionResult<ServiceResponce<List<Shared.Client>>>> AddClient(Shared.Client client)
        {
            var response = await ClientService.AddClient(client);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponce<List<Shared.Client>>>> UpdateClient(Shared.Client client)
        {
            var response = await ClientService.UpdateClient(client);
            return Ok(response);
        }
        [HttpDelete("clientId")]
        public async Task<ActionResult<ServiceResponce<List<Shared.Client>>>> DeleteClient(int clientId)
        {
            var response = await ClientService.DeleteClient(clientId);
            return Ok(response);
        }
    }
}
