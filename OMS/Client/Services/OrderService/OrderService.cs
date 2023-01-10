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
        public List<Product> newProducts { get; set; } = new List<Product>();

        public event Action OrdersChanged;

        public async Task AddOrder(Order order)
        {
            //Console.WriteLine(order.OrderProducts[0].Order.Id);
            Console.WriteLine(order.OrderProducts[0].Product.Name);
            var response = await http.PostAsJsonAsync("api/order/addorder", order);
            Orders = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<Order>>>()).Data;
            OrdersChanged.Invoke();
        }

        public async Task DeleteOrder(int orderId)
        {
            var response = await http.DeleteAsync($"api/order/single/{orderId}");
            Orders = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<Order>>>()).Data;
            OrdersChanged.Invoke();
        }

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
        public async Task UpdateOrder(Order order)
        {
            var response = await http.PutAsJsonAsync("api/order/update", order);
            Orders = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<Order>>>()).Data;
            OrdersChanged.Invoke();

        }
    }
}
