namespace OMS.Server.Services.StatusService
{
    public interface IStatusService
    {
        Task<ServiceResponce<List<Status>>> GetStatus();
    }
}
