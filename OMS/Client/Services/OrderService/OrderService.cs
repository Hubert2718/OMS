using System.ComponentModel;

namespace OMS.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient http;

        public OrderService(HttpClient http)
        {
            this.http = http;
        }
        public List<Order> Orders { get; set; } = new List<Order>();
        public string Message { get; set; } = "Loading orders...";

        public event Action OrdersChanged;

        public async Task GetOrders(string? statusUrl = null)
        {
            var result = statusUrl == null ?
                await http.GetFromJsonAsync<ServiceResponce<List<Order>>>("api/order") :
                await http.GetFromJsonAsync<ServiceResponce<List<Order>>>($"api/order/status/{statusUrl}");
            if (result != null && result.Data != null)
                Orders = result.Data;

            OrdersChanged.Invoke();
        }

        public async Task<ServiceResponce<Order>> GetSingleOrder(int orderId)
        {
            var result = await http.GetFromJsonAsync<ServiceResponce<Order>>($"api/order/{orderId}");
            return result;
        }

        public async Task SearchOrders(string searchText)
        {
            var result = await http.
                GetFromJsonAsync<ServiceResponce<List<Order>>>($"api/order/search/{searchText}");
            if (result != null && result.Data != null)
                Orders = result.Data;
            if (Orders.Count == 0 )
            {
                Message = "No orders found.";
            }
            OrdersChanged?.Invoke();
            
        }
    }
}
