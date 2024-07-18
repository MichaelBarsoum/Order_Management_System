using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order_Management_System.CORE.Contracts.Services.Orders;
using Order_Management_System.Repositories.Models;
using Order_Management_System.Repository.OrderState;
using OrderManagementSystem.API.DTOs.Order;
using OrderManagementSystem.API.Errors;

namespace OrderManagementSystem.API.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;
        private readonly IOrderState _orderState;

        public OrdersController(IOrderServices orderServices , IMapper mapper , IOrderState orderState)
        {
            _orderServices = orderServices;
            _mapper = mapper;
            _orderState = orderState;
        }
        //POST /api/orders - Create a new order

        [HttpPost]
        [ProducesResponseType(typeof(Order),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Order>> CreateNewOrder(OrderDTO order)
        {
            if (order == null) return NotFound(new ApiErrorResponse(404, " No Order Found To Create it !"));
            var MappedOrder = _mapper.Map<Order>(order);
            await _orderServices.CreateOrderAsync(MappedOrder);
            _orderState.HandleState(MappedOrder);
            return Ok(MappedOrder);
        }

        //GET /api/orders/{orderId} - Get details of a specific order

        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> GetOrderDetailsById(int orderId)
        {
            var order = await _orderServices.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound(new ApiErrorResponse(404, $"Order with ID : {orderId} Not Found!"));
            var MappedOrder = _mapper.Map<OrderDTO>(order);
            return Ok(MappedOrder);
        }

        // GET /api/orders - Get all orders (admin only)

        [Authorize(Roles ="Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            var orders = await _orderServices.GetAllOrdersAsync();
            if (orders == null) return NotFound(new ApiErrorResponse(404, "No Orders Found !"));
            var MappedOrder = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return Ok(MappedOrder);
        }

        // PUT /api/orders/{orderId}/status - Update order status (admin only)

        [Authorize(Roles = "Admin")]
        [HttpPut("{orderId}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateOrderStatus(int orderId, string updatedOrder)
        {
            var order = await _orderServices.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound(new ApiErrorResponse(404, "Order Not Found!"));
            if (updatedOrder is null) return NotFound(new ApiErrorResponse(404, "Status Not Found!"));
            await _orderServices.UpdateOrderStatusAsync(orderId,updatedOrder);
            return Ok("Order Status Updated Successfully");
        }
    }
}
