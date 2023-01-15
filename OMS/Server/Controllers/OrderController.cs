using Microsoft.AspNetCore.Mvc;
using OMS.Server.Services.ProductService;
using OMS.Shared;

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

        [HttpDelete("{orderId}")]
        public async Task<ActionResult<ServiceResponce<List<Order>>>> DeleteOrder(int orderId)
        {
            var response = await orderService.DeleteOrder(orderId);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost]
        [Route("addorder")]
        public async Task<ActionResult<ServiceResponce<List<Order>>>> AddOrder(Order order)
        {
            var response = await orderService.AddOrder(order);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponce<List<Order>>>> UpdateOrder(Order order)
        {
            var response = await orderService.UpdateOrder(order);
            if (!response.Success)
                return BadRequest(response);
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
