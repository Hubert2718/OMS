namespace OMS.Server.Services.ProductService
{
    public interface IOrderService
    {
        Task<ServiceResponce<List<Order>>> GetOrdersAsync();
        Task<ServiceResponce<Order>> GetSingleOrderAsync(int orderId);
        Task<ServiceResponce<List<Order>>> GetOrdersByStatus(string categoryUrl);
        Task<ServiceResponce<List<Order>>> SearchOrders(string searchText);
        Task<ServiceResponce<List<Order>>> AddOrder(Order order);
        Task<ServiceResponce<List<Order>>> UpdateOrder(Order order);
        Task<ServiceResponce<List<Order>>> DeleteOrder(int orderId);
    }
}
