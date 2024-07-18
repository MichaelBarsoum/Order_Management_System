using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order_Management_System.Repositories.Models;

namespace Order_Management_System.CORE.Configurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id).IsClustered();
            builder.HasOne(I => I.Order).WithOne();
            builder.Property(I => I.TotalAmount).HasColumnType("decimal(18,2)");
        }
    }
}
