namespace OMS.Server.Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly DataContext dataContext;

        public StatusService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ServiceResponce<List<Status>>> GetStatus()
        {
            var status = await dataContext.Status.ToListAsync();
            return new ServiceResponce<List<Status>>
            {
                Data = status
            };
        }
    }
}
