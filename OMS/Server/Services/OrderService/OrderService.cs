using Microsoft.EntityFrameworkCore;
using OMS.Server.Services.ProductService;

namespace OMS.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext dataContext;

        public OrderService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<ServiceResponce<Order>> GetSingleOrderAsync(int orderId)
        {
            var response = new ServiceResponce<Order>();
            var order = await dataContext.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Include(o => o.Client)
                .Include(o => o.Address)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                response.Success = false;
                response.Message = $"Sorry order {orderId} does not exist.";
            }
            else
            {
                response.Data = order;
            }
            return response;
        }

        public async Task<ServiceResponce<List<Order>>> GetOrdersAsync()
        {
            var response = new ServiceResponce<List<Order>>()
            {
                Data = await dataContext.Orders
                    .Include(o => o.OrderProducts)
                    .Include(o => o.Client)
                    .Include(o => o.Address)
                    .Include(o => o.Status)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponce<List<Order>>> GetOrdersByStatus(string statusUrl)
        {
            var response = new ServiceResponce<List<Order>>()
            {
                Data = await dataContext.Orders
                    .Where(o => o.Status.Url.ToLower().Equals(statusUrl.ToLower()))
                    .Include(o => o.OrderProducts)
                    .ToListAsync()
            };
            return response;

        }

        public async Task<ServiceResponce<List<Order>>> SearchOrders(string searchText)
        {
            var response = new ServiceResponce<List<Order>>
            {
                Data = await FindOrderBySearchText(searchText)
            };
            return response;
        }

        private async Task<List<Order>> FindOrderBySearchText(string searchText)
        {
            return await dataContext.Orders
                    .Include(o => o.Client)
                    .Where(o => o.Client.Name.ToLower().Contains(searchText.ToLower())
                    ||
                    o.Client.Name.ToLower().Contains(searchText.ToLower()))
                    .ToListAsync();
        }

        public async Task<ServiceResponce<List<Order>>> AddOrder(Order order)
        {
            order.Editing = order.IsNew = false;
            dataContext.Orders.Add(order);
            dataContext.SaveChangesAsync();
            return await GetOrdersAsync();
        }

        public async Task<ServiceResponce<List<Order>>> UpdateOrder(Order order)
        {
            var dbOrder = await dataContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if(dbOrder == null)
            {
                return new ServiceResponce<List<Order>>
                {
                    Success = false,
                    Message = $"Order with ID: {order.Id} not found in the database"
                };
            }

            dbOrder.Status = order.Status;
            dbOrder.Address = order.Address;
            dbOrder.OrderProducts = order.OrderProducts;

            dataContext.SaveChangesAsync();
            return await GetOrdersAsync();
        }

        public Task<ServiceResponce<List<Order>>> DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
