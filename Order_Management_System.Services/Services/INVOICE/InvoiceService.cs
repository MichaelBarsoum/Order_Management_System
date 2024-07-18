using Order_Management_System.CORE.Contracts;
using Order_Management_System.CORE.Contracts.Services.Invoices;
using Order_Management_System.Repositories.Models;

namespace Order_Management_System.Services.Services.INVOICE
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IGenericRepository<Invoice> _InvoiceRepo;

        public InvoiceService(IGenericRepository<Invoice> InvoiceRepo)
        {
            _InvoiceRepo = InvoiceRepo;
        }
        public async Task<Invoice> GenerateInvoiceAsync(Order order)
        {
            var invoice = new Invoice
            {
                OrderId = order.Id,
                InvoiceDate = order.OrderDate.ToString(),
                TotalAmount = order.TotalAmount,
            };
           await _InvoiceRepo.CreateAsync(invoice);
            return invoice;
        }
    }
}
