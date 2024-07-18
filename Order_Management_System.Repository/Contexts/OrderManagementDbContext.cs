using Microsoft.EntityFrameworkCore;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.CORE.Contexts
{
    public class OrderManagementDbContext : DbContext
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> Options):base(Options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
    }
}
