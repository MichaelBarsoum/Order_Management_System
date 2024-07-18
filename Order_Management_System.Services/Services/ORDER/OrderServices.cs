using Order_Management_System.CORE.Contracts;
using Order_Management_System.CORE.Contracts.Services.Invoices;
using Order_Management_System.CORE.Contracts.Services.Orders;
using Order_Management_System.Repositories.Models;
using Order_Management_System.Repository.OrderState;

namespace Order_Management_System.Services.Services.ORDER
{
    public class OrderServices : IOrderServices
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderState _orderState;
        public OrderServices(IGenericRepository<Order> OrderRepo, IGenericRepository<Product> ProductRepo,
                             IInvoiceService invoiceService,IOrderState orderState)
        {
            _orderRepo = OrderRepo;
            _productRepo = ProductRepo;
            _invoiceService = invoiceService;
            _orderState = orderState;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            foreach (var item in order.OrderItems)
            {
                var eachItem = await _orderRepo.GetByIdAsync(item.Id);
                if (eachItem is null) throw new InvalidOperationException($" Item with ID : {item.Id} Not Found !");
                var product = await _productRepo.GetByIdAsync(item.Product.Id);
                if (product is null && product.Stock < item.Quantity)
                    throw new InvalidOperationException("Insufficient stock for product");
                product.Stock -= item.Quantity;
            }
            order.TotalAmount = CalculateTotalAmount(order);
            await _orderRepo.CreateAsync(order);
            if (order.State.ToString() == "Placed")
                await _invoiceService.GenerateInvoiceAsync(order);
            return order;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _orderRepo.GetAllAsync();
        public async Task<Order> GetOrderByIdAsync(int orderId) => await _orderRepo.GetByIdAsync(orderId);
        public async Task<Order> UpdateOrderStatusAsync(int orderId, string? status)
        {
            var order = await GetOrderByIdAsync(orderId);
            if (order is null) return new Order();
            _orderState.HandleState(order);
            await _orderRepo.UpdateAsync(order);
            return order;
        }
        private decimal CalculateTotalAmount(Order order)
        {
            var TotalAmount = order.OrderItems.Sum(OI => OI.Quantity * OI.UnitPrice);
            if (TotalAmount > 200)
                TotalAmount *= 0.1m;
            else if (TotalAmount > 100)
                TotalAmount *= 0.05m;
            return TotalAmount;
        }
        




    }
}
