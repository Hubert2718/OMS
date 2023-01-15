using Microsoft.EntityFrameworkCore;

namespace OMS.Server.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly DataContext dataContext;

        public ClientService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<ServiceResponce<List<Shared.Client>>> AddClient(Shared.Client client)
        {
            await dataContext.Clients.AddAsync(client);
            await dataContext.SaveChangesAsync();
            return await GetClientsAsync();
        }

        public async Task<ServiceResponce<List<Shared.Client>>> DeleteClient(int clientId)
        {
            OMS.Shared.Client client = await dataContext.Clients.Where(c => c.Id == clientId).FirstOrDefaultAsync();
            dataContext.Remove(client);
            await dataContext.SaveChangesAsync();
            return await GetClientsAsync();
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

        public async Task<ServiceResponce<List<Shared.Client>>> UpdateClient(Shared.Client client)
        {
            Shared.Client dbClient = await dataContext.Clients.Where(c => c.Id == client.Id).FirstOrDefaultAsync();

            dbClient.Name = client.Name;
            dbClient.Surname = client.Surname;
            dbClient.Email = client.Email;
            dbClient.PhoneNumber = client.PhoneNumber;

            await dataContext.SaveChangesAsync();

            return await GetClientsAsync();
        }
    }
}
