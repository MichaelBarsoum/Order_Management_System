namespace OrderManagementSystem.API.DTOs.Invoice
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
