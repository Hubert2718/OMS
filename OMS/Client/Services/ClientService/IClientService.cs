namespace OMS.Client.Services.ClientService
{
    public interface IClientService
    {
        event Action ClientsChanged;
        string Message { get; set; }
        List<OMS.Shared.Client> Clients { get; set; }
        Task GetClients();
        Task<ServiceResponce<OMS.Shared.Client>> GetSingleClient(int clientId);
        Task SearchClients(string searchText);
        Task AddClient(OMS.Shared.Client client);
        Task RemoveClient(int clientId);
        Task UpdateClient(OMS.Shared.Client client);
        OMS.Shared.Client CreateNewClient();
    }
}
