using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order_Management_System.Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repository.Configurations
{
    internal class PaymentMethodCofig : IEntityTypeConfiguration<PaymentMethods>
    {
        public void Configure(EntityTypeBuilder<PaymentMethods> builder)
        {
            builder.HasKey(PM => PM.Id);
            builder.HasMany(PM => PM.orders).WithOne();
        }
    }
}
