using Order_Management_System.CORE.Contexts;
using Order_Management_System.Repositories.Models;
using System.Text.Json;

namespace Order_Management_System.Repository.DataSeed
{
    public static class SeedingDataToEntities
    {
        public static async Task DataSeed(OrderManagementDbContext dbContext)
        {
            // Seed Customer Data
            if (!dbContext.Customers.Any())
            {
                var Customerdata = File.ReadAllText("../Order_Management_System.Repository/DataSeed/Data/Customer_MOCK_DATA.json");
                var Customers = JsonSerializer.Deserialize<List<Customer>>(Customerdata);
                if (Customers?.Count > 0)
                {
                    foreach (var customer in Customers)
                        await dbContext.Set<Customer>().AddAsync(customer);
                    await dbContext.SaveChangesAsync();
                }
            }
            // Seed Invoice Data
            if (!dbContext.Invoices.Any())
            {
                var Invoicedata = File.ReadAllText("../Order_Management_System.Repository/DataSeed/Data/Invoice_MOCK_DATA.json");
                var Invoices = JsonSerializer.Deserialize<List<Invoice>>(Invoicedata);
                if (Invoices?.Count > 0)
                {
                    foreach (var invoice in Invoices)
                        await dbContext.Set<Invoice>().AddAsync(invoice);
                    await dbContext.SaveChangesAsync();
                }
            }
            // Seed OrderItems Data
            if (!dbContext.OrderItems.Any())
            {
                var OrderItemsdata = File.ReadAllText("../Order_Management_System.Repository/DataSeed/Data/Order_Items_MOCK_DATA.json");
                var orderItem = JsonSerializer.Deserialize<List<OrderItem>>(OrderItemsdata);
                if (orderItem?.Count > 0)
                {
                    foreach (var item in orderItem)
                        await dbContext.Set<OrderItem>().AddAsync(item);
                    await dbContext.SaveChangesAsync();
                }
            }

            // Seed Product Data
            if (!dbContext.Products.Any())
            {
                var Productdata = File.ReadAllText("../Order_Management_System.Repository/DataSeed/Data/Product_MOCK_DATA.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(Productdata);
                if (Products?.Count > 0)
                {
                    foreach (var product in Products)
                        await dbContext.Set<Product>().AddAsync(product);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
