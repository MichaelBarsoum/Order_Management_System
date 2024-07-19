using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.CORE.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(O => O.Id).IsClustered();
            builder.HasOne(O => O.Customer).WithMany(O => O.Orders).HasForeignKey(O => O.CustomerId);
            builder.HasOne(O => O.paymentMethod).WithMany().HasForeignKey(O => O.paymentMethodId);
            builder.HasMany(O => O.OrderItems).WithOne();
            builder.Property(O => O.TotalAmount).HasColumnType("decimal(18,2)");
            //builder.Property(O => O.PayMethod).HasColumnType("nvarchar(50)");
            builder.Property(O => O.Status).HasConversion(O => O.ToString(), O =>(OrderStatus) Enum.Parse(typeof(OrderStatus) , O ));
            builder.OwnsOne(O => O.Address, Add => Add.WithOwner());
        }
    }
}
