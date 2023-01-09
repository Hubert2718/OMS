using OMS.Shared;

namespace OMS.Client.Services.OrderService
{
    public interface IOrderService
    {
        event Action OrdersChanged;
        string Message { get; set; }
        List<Order> Orders { get; set; }
        Task GetOrders(string? statusUrl = null);
        Task<ServiceResponce<Order>> GetSingleOrder(int orderId);
        Task SearchOrders(string searchText);
    }
}
