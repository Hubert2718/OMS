namespace OMS.Client.Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly HttpClient httpClient;

        public StatusService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public List<Status> StatusList { get; set; } = new List<Status>();

        public async Task GetStatusList()
        {
            var response = await httpClient.GetFromJsonAsync<ServiceResponce<List<Status>>>("api/Status");
            if(response!=null && response.Data != null)
                StatusList = response.Data;
        }
    }
}
