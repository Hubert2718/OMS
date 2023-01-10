namespace OMS.Server.Services.ClientService
{
    public interface IClientService
    {
        Task<ServiceResponce<List<Shared.Client>>> GetClientsAsync();
        Task<ServiceResponce<Shared.Client>> GetSingleClient(int clientId);
        Task<ServiceResponce<List<Shared.Client>>> SearchClients(string searchText);
        Task<ServiceResponce<List<Shared.Client>>> AddClient(Shared.Client client);
        Task<ServiceResponce<List<Shared.Client>>> UpdateClient(Shared.Client client);
        Task<ServiceResponce<List<Shared.Client>>> DeleteClient(int clientId);
    }
}
