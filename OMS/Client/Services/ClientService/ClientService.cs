using OMS.Shared;
using System.ComponentModel;
using System.Net.Http;

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

        public async Task AddClient(OMS.Shared.Client client)
        {
            var response = await http.PostAsJsonAsync("api/client", client);
            Clients = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<OMS.Shared.Client>>>()).Data;
            ClientsChanged.Invoke();
        }

        public async Task RemoveClient(int clientId)
        {
            var response = await http.DeleteAsync($"api/client/{clientId}");
            Clients = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<OMS.Shared.Client>>>()).Data;
            ClientsChanged.Invoke();
        }

        public async Task UpdateClient(OMS.Shared.Client client)
        {
            var response = await http.PutAsJsonAsync("api/client", client);
            Clients = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<OMS.Shared.Client>>>()).Data;
            ClientsChanged.Invoke();
        }

        public OMS.Shared.Client CreateNewClient()
        {
            var newClient = new OMS.Shared.Client { IsNew = true, Editing = true };
            Clients.Add(newClient);
            ClientsChanged.Invoke();
            return newClient;
        }
    }
}
