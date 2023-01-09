using System.ComponentModel;

namespace OMS.Client.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly HttpClient http;

        public string Message { get; set; } = "Loading Clients...";
        public List<OMS.Shared.Client> Clients { get; set; } = new List<OMS.Shared.Client>();  

        public event Action ClientsChanged;

        public ClientService(HttpClient http)
        {
            this.http = http;
        }

        public async Task GetClients()
        {
            var result = await http.GetFromJsonAsync<ServiceResponce<List<OMS.Shared.Client>>>("api/client");
            if (result != null && result.Data != null) 
                Clients = result.Data;

            ClientsChanged.Invoke();
        }

        public Task<ServiceResponce<OMS.Shared.Client>> GetSingleClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task SearchClients(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
