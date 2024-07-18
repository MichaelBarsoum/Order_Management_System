using Order_Management_System.CORE.Contracts.Services.Invoices;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using Order_Management_System.Repository.OrderState;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Management_System.CORE.OrderState
{
    [NotMapped]
    public class OrderState : IOrderState
    {
        private readonly IInvoiceService _invoiceService;

        public OrderState(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public void HandleState(Order order)
        {
            if (order.State.ToString() == "Processing")
                order.State = new OrderProcessingState(order);
            else if (order.State.ToString() == "Placed")
                order.State = new OrderPlacedState(order);
            else if (order.State.ToString() == "Delivered")
                order.State = new OrderDeliveredState(order);
            else
                order.Status = OrderStatus.Cancelled;
        }
    }
}
