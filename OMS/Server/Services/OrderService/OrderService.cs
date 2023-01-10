using Microsoft.EntityFrameworkCore;
using OMS.Server.Services.ProductService;
using OMS.Shared;

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
                    .ThenInclude(op => op.Product)
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
            Address address = order.Address;
            dataContext.Address.Add(address);
            await dataContext.SaveChangesAsync();


            order.AddressId = (await dataContext.Address
                .Where(a => a.PostalCode.Equals(address.PostalCode)
                && a.City.Equals(address.City)
                && a.BuildingNumber.Equals(address.BuildingNumber)
                && a.ApartmentNumer.Equals(address.ApartmentNumer)
                && a.Country.Equals(address.Country)
                && a.Street.Equals(address.Street))
                .FirstOrDefaultAsync()).Id;

            Order dbOrder = new Order
            {
                AddressId = order.AddressId,
                ClientId = order.ClientId,
                Date = order.Date,
                StatusId = order.StatusId

            };
            
            await dataContext.Orders.AddAsync(dbOrder);
            await dataContext.SaveChangesAsync();
            await GetOrdersAsync();

            foreach (var orderProduct in order.OrderProducts)
            {
                await AddOrderProducts(orderProduct);
            }

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
            dbOrder.StatusId = order.StatusId;
            dbOrder.Address = order.Address;
            dbOrder.OrderProducts = order.OrderProducts;

            await dataContext.SaveChangesAsync();
            return await GetOrdersAsync();
        }

        public async Task<ServiceResponce<List<Order>>> DeleteOrder(int orderId)
        {
            var dbOrder = await dataContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (dbOrder == null)
            {
                return new ServiceResponce<List<Order>>
                {
                    Success = false,
                    Message = $"Order with ID: {orderId} not found in the database"
                };
            }

            dbOrder.Deleted = true;
            dataContext.Remove(dbOrder);
            dataContext.SaveChangesAsync();
            return await GetOrdersAsync();
        }

        private async Task AddOrderProducts(OrderProducts orderProducts)
        {
            OrderProducts toisert = new OrderProducts
            {
                OrderId = orderProducts.OrderId,
                ProductId = orderProducts.ProductId
            };
            await dataContext.OrderProducts.AddAsync(toisert);
            await dataContext.SaveChangesAsync();
        }
    }
}
