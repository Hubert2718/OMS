namespace OMS.Server.Services.ClientService
{
    public interface IClientService
    {
        Task<ServiceResponce<List<Shared.Client>>> GetClientsAsync();
        Task<ServiceResponce<Shared.Client>> GetSingleClient(int clientId);
        Task<ServiceResponce<List<Shared.Client>>> SearchClients(string searchText);
    }
}
