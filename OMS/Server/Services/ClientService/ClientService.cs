namespace OMS.Server.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly DataContext dataContext;

        public ClientService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ServiceResponce<List<Shared.Client>>> GetClientsAsync()
        {
            var response = new ServiceResponce<List<Shared.Client>>()
            {
                Data = await dataContext.Clients.ToListAsync()
            };

            return response;
        }
        public Task<ServiceResponce<Shared.Client>> GetSingleClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponce<List<Shared.Client>>> SearchClients(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
