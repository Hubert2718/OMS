using Microsoft.AspNetCore.Mvc;
using OMS.Server.Services.ProductService;

namespace OMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponce<List<Order>>>> GetOrders()
        {
            var response = await orderService.GetOrdersAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<ActionResult<ServiceResponce<Order>>> GetSingleOrder(int orderId)
        {
            var response = await orderService.GetSingleOrderAsync(orderId);
            return Ok(response);
        }

        [HttpGet]
        [Route("status/{statusUrl}")]
        public async Task<ActionResult<ServiceResponce<List<Order>>>> GetOrdersByStatus(string statusUrl)
        {
            var response = await orderService.GetOrdersByStatus(statusUrl);
            return Ok(response);
        }

        [HttpGet]
        [Route("search/{searchText}")]
        public async Task<ActionResult<ServiceResponce<List<Order>>>> SearchOrders(string searchText)
        {
            var response = await orderService.SearchOrders(searchText);
            return Ok(response);
        }
    }
}
