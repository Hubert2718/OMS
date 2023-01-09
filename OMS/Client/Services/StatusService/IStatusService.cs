namespace OMS.Client.Services.StatusService
{
    public interface IStatusService
    {
        List<Status> StatusList { get; set; }
        Task GetStatusList();
    }
}
