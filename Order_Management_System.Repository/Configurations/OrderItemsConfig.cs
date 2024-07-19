using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.CORE.Configurations
{
    public class OrderItemsConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id).IsClustered();
            builder.HasOne(OI => OI.Order).WithMany(OI => OI.OrderItems).HasForeignKey(OI => OI.OrderId);
            builder.HasOne(OI => OI.Product).WithOne();
            builder.Property(OI => OI.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(OI => OI.Discount).HasColumnType("decimal(18,2)");
            // builder.OwnsOne(OI => OI.Product, OI => OI.WithOwner());
        }
    }
}
